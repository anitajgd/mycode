using System.Xml.Linq;

namespace testJuego.Domain
{
    public class Dice
    {
        private int _value1 = 1; 

        private int _value2 = 6; 

        // Menos valor del dado
        private int Value1 
        {
            get => _value1;
            set => _value1 = value;
        }

        // Mayor valor del dado 
        private int Value2
        {
            get => _value2;
            set => _value2 = value;
        }

        public int GetValue()
        {
            Random r = new Random();

            //Genera un numero entre 10 y 100 (101 no se incluye)
            int randomV = r.Next(Value1, Value2);

            return randomV;
        }
    }
}
