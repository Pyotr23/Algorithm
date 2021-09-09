using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Four.ElementalWords
{
    internal class ElementCollection
    {
        private static readonly Dictionary<string, string> Elements = new()
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
                      /*16*/ { "S", "Sulfur" },
                      /*17*/ { "Cl", "Хлор (Cl)" },
                      /*18*/ { "Ar", "Аргон (Ar)" },
                      /*19*/ { "K", "Potassium" },
                      /*20*/ { "Ca", "Кальций (Ca)" },
                      /*21*/ { "Sc", "Скандий (Sc)" },
                      /*22*/ { "Ti", "Титан (Ti)" },
                      /*23*/ { "V", "Vanadium" },
                      /*24*/ { "Cr", "Хром (Cr)" },
                      /*25*/ { "Mn", "Марганец (Mn)" },
                      /*26*/ { "Fe", "Железо (Fe)" },
                      /*27*/ { "Co", "Cobalt" },
                      /*28*/ { "Ni", "Nickel" },
                      /*29*/ { "Cu", "Медь (Cu)" },
                      /*30*/ { "Zn", "Цинк (Zn)" },
                      /*31*/ { "Ga", "Галлий (Ga)" },
                      /*32*/ { "Ge", "Germanium" },
                      /*33*/ { "As", "Мышьяк (As)" },
                      /*34*/ { "Se", "Селен (Sa)" },
                      /*35*/ { "Br", "Бром (Be)" },
                      /*36*/ { "Kr", "Криптон (Kr)" },
                      /*37*/ { "Rb", "Рубидий (Rb)" },
                      /*38*/ { "Sr", "Стронций (Sr)" },
                      /*39*/ { "Y", "Yttrium" },
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
                      /*50*/ { "Sn", "Tin" },
                      /*51*/ { "Sb", "Сурьма (Sb)" },
                      /*52*/ { "Te", "Теллур (Te)" },
                      /*53*/ { "I", "Iodine" },
                      /*54*/ { "Xe", "Ксенон (Xe)" },
                      /*55*/ { "Cs", "Цезий (Cs)" },
                      /*56*/ { "Ba", "Барий (Ba)" },
                      /*57*/ { "La", "Lanthanum" },
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
                      /*68*/ { "Er", "Erbium" },
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
                      /*89*/ { "Ac", "Actinium " },
                      /*90*/ { "Th", "Торий (Th)" },
                      /*91*/ { "Pa", "Протактиний (Pa)" },
                      /*92*/ { "U", "Уран (U)" },
                      /*93*/ { "Np", "Нептуний (Np)" },
                      /*94*/ { "Pu", "Плутоний (Pu)" },
                      /*95*/ { "Am", "Америций (Am)" },
                      /*96*/ { "Cm", "Кюрий (Cm)" },
                      /*97*/ { "Bk", "Берклий (Bk)" },
                      /*98*/ { "Cf", "Калифорний (Cf)" },
                      /*99*/ { "Es", "Einsteinium" },
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

        private static IEnumerable<string> LowerCaseElementKeyHashSet => Elements
            .Keys
            .Select(key => key.ToLower())
            .ToHashSet();

        private string GetElementDescription(string anyCaseKey)
        {
            var elementKey = Elements
                .Keys
                .FirstOrDefault(key => key.Equals(anyCaseKey, StringComparison.OrdinalIgnoreCase));

            return elementKey is null
                ? string.Empty
                : $"{Elements[elementKey]} ({elementKey})";
        }
        
        internal string[][] GetElementalForms(IEnumerable<IEnumerable<string>> elementalFormList)
        {
            return elementalFormList
                .Select(x => x
                    .Select(GetElementDescription)
                    .ToArray())
                .ToArray();
        }

        internal IEnumerable<string> GetElementKeys(string word)
        {
            return LowerCaseElementKeyHashSet.Where(word.StartsWith);
        }
        
        internal IEnumerable<string> GetElementKeys(string word, IEnumerable<string> elementKeys)
        {
            var beginning = StringHelper.GetJoinedString(elementKeys);
            return LowerCaseElementKeyHashSet.Where(k => word.StartsWith(beginning + k));
        }
    }
}