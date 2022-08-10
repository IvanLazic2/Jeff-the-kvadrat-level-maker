using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeff_The_Kvadrat_Level_Maker.Models
{
    public class SpritePart
    {
        public int[,] Array { get; set; }
        public int[] ConvertedArray { get; set; }

        public SpritePart()
        {
            Array = new int[16, 16];
            ConvertedArray = new int[16];
        }

        public bool IsEmpty()
        {
            return ConvertedArray.All(x => x == 0);
        }

        public void ConvertArray()
        {
            for (int i = 0; i < 16; i++)
            {
                //get grid binary representation
                string binary = "";
                for (int j = 0; j < 16; j++)
                {
                    if (Array[i, j] == 1)
                        binary = "1" + binary;
                    else
                        binary = "0" + binary;
                }

                bool isNegative = false;
                //if number is negative, get its  one's complement
                if (binary[0] == '1')
                {
                    isNegative = true;
                    string oneComplement = "";
                    for (int k = 0; k < 16; k++)
                    {
                        if (binary[k] == '1')
                            oneComplement = oneComplement + "0";
                        else
                            oneComplement = oneComplement + "1";
                    }
                    binary = oneComplement;
                }

                //calculate one's complement decimal value
                int value = 0;
                for (int k = 0; k < 16; k++)
                {
                    value = value * 2;
                    if (binary[k] == '1')
                        value = value + 1;
                }

                //two's complement value if it is a negative value
                if (isNegative == true)
                    value = -(value + 1);

                ConvertedArray[i] = value;
            }
        
        }
    }
}
