using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Five.HungerGames
{
    class Program
    {
        private const string Antelope = "antelope";
        private const string Grass = "grass";
        private const string BigFish = "big-fish";
        private const string LittleFish = "little-fish";
        private const string Bug = "bug";
        private const string Leaves = "leaves";
        private const string Bear = "bear";
        private const string Chicken = "chicken";
        private const string Cow = "cow";
        private const string Sheep = "sheep";
        private const string Fox = "fox";
        private const string Giraffe  = "giraffe";
        private const string Lion  = "lion";
        private const string Panda  = "panda";

        private static readonly Dictionary<string, IEnumerable<string>> EatingRules = new()
        {
            {Antelope, new[] {Grass}},
            {BigFish, new[] {LittleFish}},
            {Bug, new[] {Leaves}},
            {Bear, new[] {BigFish, Bug, Chicken, Cow, Leaves, Sheep}},
            {Chicken, new[] {Bug,}},
            {Cow, new[] {Grass}},
            {Fox, new[] {Chicken, Sheep}},
            {Giraffe, new[] {Leaves}},
            {Lion, new[] {Antelope, Cow}},
            {Panda, new[] {Leaves}},
            {Sheep, new[] {Grass}}
        };
        private static LinkedList<string> _zooLinkedList;
        private static List<string> _messages;

        private static void Main(string[] args)
        {
            const string zoo = "bear,big-fish,bug,chicken,cow,leaves,sheep";
            foreach (var message in WhoEatsWho(zoo))
                Console.WriteLine(message);
        }
        
        public static string[] WhoEatsWho(string zoo)
        {
            if (string.IsNullOrEmpty(zoo))
                return new string[] {string.Empty, string.Empty};
            _zooLinkedList = new LinkedList<string>();
            _messages = new List<string>();
            _messages.Add(zoo);
            
            var animals = zoo.Split(',');
            foreach (var animal in animals)
                _zooLinkedList.AddLast(animal);
           
            Eat(_zooLinkedList.First, true);
            _messages.Add(string.Join(",", _zooLinkedList));
            return _messages.ToArray();
        }

        private static void Eat(LinkedListNode<string> animalNode, bool checkNext = false)
        {
            if (CanEatLeftAnimal(animalNode))
            {
                _messages.Add($"{animalNode.Value} eats {animalNode.Previous.Value}");
                _zooLinkedList.Remove(animalNode.Previous);
                if (animalNode.Previous != null)
                {
                    Eat(animalNode.Previous, true);
                    return;
                }
            }
            
            EatRight(animalNode);

            if (checkNext)
            {
                if (animalNode?.Next == null)
                {
                    return;
                }
                
                Eat(animalNode.Next, true);
            }
        }

        private static bool CanEatLeftAnimal(LinkedListNode<string> animalNode)
        {
            if (animalNode == null)
                return false;
            var leftAnimal = animalNode?.Previous;
            return leftAnimal != null 
                   && EatingRules.ContainsKey(animalNode.Value)
                   && EatingRules[animalNode.Value].Contains(leftAnimal.Value);
        }

        private static void EatRight(LinkedListNode<string> animalNode)
        {
            if (!CanEatRightAnimal(animalNode)) 
                return;
            
            _messages.Add($"{animalNode.Value} eats {animalNode.Next.Value}");
            _zooLinkedList.Remove(animalNode.Next);
            EatRight(animalNode);
        }
        
        private static bool CanEatRightAnimal(LinkedListNode<string> animalNode)
        {
            var rightAnimal = animalNode?.Next;
            return rightAnimal != null 
                   && EatingRules.ContainsKey(animalNode.Value)
                   && EatingRules[animalNode.Value].Contains(rightAnimal.Value);
        }
    }
}