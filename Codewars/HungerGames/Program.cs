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

        private static readonly Dictionary<string, IEnumerable<string>> EatingRules 
            = new Dictionary<string, IEnumerable<string>>()
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

        private static void Main(string[] args)
        {
            const string zoo = "bear,big-fish,bug,chicken,cow,leaves,sheep";
            foreach (var message in WhoEatsWho(zoo))
                Console.WriteLine(message);
        }
        
        public static string[] WhoEatsWho(string zoo)
        {
            if (string.IsNullOrEmpty(zoo))
                return new string[] {string.Empty};
            
            var zooLinkedList = new LinkedList<string>();

            var messages = new List<string>();
            messages.Add(zoo);

            foreach (var animal in zoo.Split(','))
                zooLinkedList.AddLast(animal);
           
            Eat(zooLinkedList.First, messages);
            
            messages.Add(string.Join(",", zooLinkedList));
            
            return messages.ToArray();
        }

        private static void Eat(LinkedListNode<string> animalNode, List<string> messages)
        {
            if (CanEatLeftAnimal(animalNode))
            {
                messages.Add($"{animalNode.Value} eats {animalNode.Previous.Value}");
                
                animalNode.List.Remove(animalNode.Previous);
                
                if (animalNode.Previous != null)
                {
                    Eat(animalNode.Previous, messages);
                    return;
                }
            }
            
            EatRight(animalNode, messages);

            if (animalNode?.Next == null)
                return;
                
            Eat(animalNode.Next, messages);
        }

        private static bool CanEatLeftAnimal(LinkedListNode<string> animalNode)
        {
            if (animalNode == null)
                return false;
            
            var leftAnimal = animalNode.Previous;
            return leftAnimal != null 
                   && EatingRules.ContainsKey(animalNode.Value)
                   && EatingRules[animalNode.Value].Contains(leftAnimal.Value);
        }

        private static void EatRight(LinkedListNode<string> animalNode, List<string> messages)
        {
            if (!CanEatRightAnimal(animalNode)) 
                return;
            
            messages.Add($"{animalNode.Value} eats {animalNode.Next.Value}");
            
            animalNode.List.Remove(animalNode.Next);
            
            EatRight(animalNode, messages);
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