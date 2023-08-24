using HW2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Managers
{
    public class PositionManager
    {
        private Dictionary<string, int> map;

        public PositionManager()
        {
            this.map = new Dictionary<string, int>()
            {
                {"a",0 },
                {"b",1 },
                {"c",2 },
                {"d",3 },
                {"e",4 },
                {"f",5 },
                {"g",6 },
                {"h",7 },
            };
        }
        public bool ValidateInput(string input)
        {
            return ExtractLetter(input) != -1 && ExtractNumber(input) != -1;
        }

        public Position ParseInput(string input)
        {
            return new Position(x: RevertNumberToIndex(ExtractNumber(input)), y: ExtractLetter(input));          
        }

        private int ExtractLetter(string input)
        {
            string letter = input.First(ch => char.IsLetter(ch)).ToString().ToLower();

            if (map.ContainsKey(letter))
                return map[letter];
            else
                return -1;
        }

        private int ExtractNumber(string input)
        {
            int number = int.Parse(input.First(ch => char.IsDigit(ch)).ToString());

            if(number < 9)
                return number;  
            else 
                return -1;
        }

        private int RevertNumberToIndex(int number)
        {
            return 8 - number;
        }
    }
}
