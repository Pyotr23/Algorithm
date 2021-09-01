﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementalWords
{
    class Program
    {
        private static readonly Dictionary<string, string> ELEMENTS = new()
        {
                      /*1*/ { "H", "Hydrogen" },
                      /*2*/ { "He", "Helium" },
                      /*3*/ { "Li", "Lithium" },
                      /*4*/ { "Be", "Beryllium" },
                      /*5*/ { "B", "Boron" },
                      /*6*/ { "C", "Carbon" },
                      /*7*/ { "N", "Nitrogen" },
                      /*8*/ { "O", "Oxygen" },
                      /*9*/ { "F", "Fluorine" },
                      /*10*/ { "Ne", "Neon" },
                      /*11*/ { "Na", "Sodium" },
                      /*12*/ { "Mg", "Magnesium" },
                      /*13*/ { "Al", "Aluminium" },
                      /*14*/ { "Si", "Silicon" },
                      /*15*/ { "P", "Phosphorus" },
                      /*16*/ { "S", "Сера (S)" },
                      /*17*/ { "Cl", "Хлор (Cl)" },
                      /*18*/ { "Ar", "Аргон (Ar)" },
                      /*19*/ { "K", "Калий (K)" },
                      /*20*/ { "Ca", "Кальций (Ca)" },
                      /*21*/ { "Sc", "Скандий (Sc)" },
                      /*22*/ { "Ti", "Титан (Ti)" },
                      /*23*/ { "V", "Ванадий (V)" },
                      /*24*/ { "Cr", "Хром (Cr)" },
                      /*25*/ { "Mn", "Марганец (Mn)" },
                      /*26*/ { "Fe", "Железо (Fe)" },
                      /*27*/ { "Co", "Кобальт (Co)" },
                      /*28*/ { "Ni", "Никель (Ni)" },
                      /*29*/ { "Cu", "Медь (Cu)" },
                      /*30*/ { "Zn", "Цинк (Zn)" },
                      /*31*/ { "Ga", "Галлий (Ga)" },
                      /*32*/ { "Ge", "Германий (Ge)" },
                      /*33*/ { "As", "Мышьяк (As)" },
                      /*34*/ { "Se", "Селен (Sa)" },
                      /*35*/ { "Br", "Бром (Be)" },
                      /*36*/ { "Kr", "Криптон (Kr)" },
                      /*37*/ { "Rb", "Рубидий (Rb)" },
                      /*38*/ { "Sr", "Стронций (Sr)" },
                      /*39*/ { "Y", "Иттрий (Y)" },
                      /*40*/ { "Zr", "Цирконий (Zn)" },
                      /*41*/ { "Nb", "Ниобий (Nb)" },
                      /*42*/ { "Mo", "Молибден (Mo)" },
                      /*43*/ { "Tc", "Технеций (Tc)" },
                      /*44*/ { "Ru", "Рутений (Ru)" },
                      /*45*/ { "Rh", "Родий (Rh)" },
                      /*46*/ { "Pd", "Палладий (Pd)" },
                      /*47*/ { "Ag", "Серебро (Ag)" },
                      /*48*/ { "Cd", "Кадмий (Cd)" },
                      /*49*/ { "In", "Индий (In)" },
                      /*50*/ { "Sn", "Олово (Sn)" },
                      /*51*/ { "Sb", "Сурьма (Sb)" },
                      /*52*/ { "Te", "Теллур (Te)" },
                      /*53*/ { "I", "Йод (I)" },
                      /*54*/ { "Xe", "Ксенон (Xe)" },
                      /*55*/ { "Cs", "Цезий (Cs)" },
                      /*56*/ { "Ba", "Барий (Ba)" },
                      /*57*/ { "La", "Лантан (La)" },
                      /*58*/ { "Ce", "Церий (Ce)" },
                      /*59*/ { "Pr", "Празеодим (Pr)" },
                      /*60*/ { "Nd", "Неодим (Nd)" },
                      /*61*/ { "Pm", "Прометий (Pm)" },
                      /*62*/ { "Sm", "Самарий (Sm)" },
                      /*63*/ { "Eu", "Европий (Eu)" },
                      /*64*/ { "Gd", "Гадолиний (Gd)" },
                      /*65*/ { "Tb", "Тербий (Tb)" },
                      /*66*/ { "Dy", "Диспрозий (Dy)" },
                      /*67*/ { "Ho", "Гольмий (Ho)" },
                      /*68*/ { "Er", "Эрбий (Er)" },
                      /*69*/ { "Tm", "Тулий (Tm)" },
                      /*70*/ { "Yb", "Иттербий (Yb)" },
                      /*71*/ { "Lu", "Лютеций (Lu)" },
                      /*72*/ { "Hf", "Гафний (Hf)" },
                      /*73*/ { "Ta", "Тантал (Ta)" },
                      /*74*/ { "W", "Вольфрам (W)" },
                      /*75*/ { "Re", "Рений (Re)" },
                      /*76*/ { "Os", "Осмий (Os)" },
                      /*77*/ { "Ir", "Иридий (Ir)" },
                      /*78*/ { "Pt", "Платина (Pt)" },
                      /*79*/ { "Au", "Золото (Au)" },
                      /*80*/ { "Hg", "Ртуть (Hg)" },
                      /*81*/ { "Tl", "Таллий (Tl)" },
                      /*82*/ { "Pb", "Свинец (Pb)" },
                      /*83*/ { "Bi", "Висмут (Bi)" },
                      /*84*/ { "Po", "Полоний (Po)" },
                      /*85*/ { "At", "Астат (At)" },
                      /*86*/ { "Rn", "Радон (Rn)" },
                      /*87*/ { "Fr", "Франций (Fr)" },
                      /*88*/ { "Ra", "Радий (Ra)" },
                      /*89*/ { "Ac", "Актиний (Ac)" },
                      /*90*/ { "Th", "Торий (Th)" },
                      /*91*/ { "Pa", "Протактиний (Pa)" },
                      /*92*/ { "U", "Уран (U)" },
                      /*93*/ { "Np", "Нептуний (Np)" },
                      /*94*/ { "Pu", "Плутоний (Pu)" },
                      /*95*/ { "Am", "Америций (Am)" },
                      /*96*/ { "Cm", "Кюрий (Cm)" },
                      /*97*/ { "Bk", "Берклий (Bk)" },
                      /*98*/ { "Cf", "Калифорний (Cf)" },
                      /*99*/ { "Es", "Эйнштейний (Es)" },
                      /*100*/ { "Fm", "Фермий (Fm)" },
                      /*101*/ { "Md", "Менделевий (Md)" },
                      /*102*/ { "No", "Нобелий (No)" },
                      /*103*/ { "Lr", "Лоуренсий (Lr)" },
                      /*104*/ { "Rf", "Резерфордий (Rf)" },
                      /*105*/ { "Db", "Дубний (Db)" },
                      /*106*/ { "Sg", "Сиборгий (Sg)" },
                      /*107*/ { "Bh", "Борий (Bh)" },
                      /*108*/ { "Hs", "Хассий (Hs)" },
                      /*109*/ { "Mt", "Мейнтнерий (Mt)" },
                      /*110*/ { "Ds", "Darmstadtium" },
                      /*111*/ { "Rg", "Roentgenium" },
                      /*112*/ { "Cn", "Copernicium" },
                      /*113*/ { "Nh", "Nihonium" },
                      /*114*/ { "Fl", "Flerovium" },
                      /*115*/ { "Mc", "Moscovium" },
                      /*116*/ { "Lv", "Livermorium" },
                      /*117*/ { "Ts", "Tennessine" },
                      /*118*/ { "Og", "Oganesson" }
                  };

        private static List<List<string>> _list = new List<List<string>>();

        private static readonly HashSet<string> _keys = ELEMENTS
            .Keys
            .Select(k => k.ToLower())
            .ToHashSet();
        
        static void Main(string[] args)
        {
            ElementalForms("snack");
        }
        
        public static string[][] ElementalForms(string word)
        {
            if (string.IsNullOrEmpty(word))
                return Array.Empty<string[]>();

            var keys = GetKeys(word);

            foreach (var key in keys)
            {
                var form = (key, new List<string> {key});
                ElementalForms(form, word);
            }
            
            return new string[0][];   
        }

        private static IEnumerable<string> GetKeys(string word)
        {
            if (string.IsNullOrEmpty(word))
                return Enumerable.Empty<string>();
            
            return _keys.Where(word.StartsWith);
        }

        private static IEnumerable<string> GetKeys(ICollection<string> list, string word)
        {
            if (string.IsNullOrEmpty(word))
                return Enumerable.Empty<string>();

            var beginning = string.Join("", list);
            
            return _keys.Where(k => word.StartsWith(beginning + k));
        }

        private static void ElementalForms((string, List<string>) obj, string wholeWord)
        {
            var (partialWord, list) = obj;
            
            if (partialWord == wholeWord)
            {
                _list.Add(list);
                return;
            }

            var keys = GetKeys(list, wholeWord);
            
            foreach (var key in keys)
            {
                var newList = new List<string>(list) {key};
                var form = (partialWord + key, newList);
                ElementalForms(form, wholeWord);
            }
        }
    }
}