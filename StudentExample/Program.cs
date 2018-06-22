using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10ProbaRaschetaPogasheniyaVHZRaz
{
    class Program
    {
        static void MessageForKredit(ref int sumDolga, ref int sumOplati, int kolichPlategey)
        {
            int schetchikOplat = 0;
            int ostatokDolga = 0;
            do
            {
                ostatokDolga = sumDolga - sumOplati;
                schetchikOplat++;
                if (ostatokDolga == 0)
                {
                    Console.WriteLine($"Вы сделали {schetchikOplat} оплат, Ваш долг {sumDolga} погашен, остаток долга {ostatokDolga}");
                    return;
                }
                else if (ostatokDolga < 0)
                {

                    Console.WriteLine($"Вы сделали {schetchikOplat} оплат, Ваш долг {sumDolga} погашен, Ваша переплата {ostatokDolga *= -1}");
                    return;
                }
                else //if (ostatokDolga > 0)
                {
                    int ostKolichPlategey = kolichPlategey - schetchikOplat;
                    if (ostKolichPlategey == 0)
                    { continue; }
                    Console.WriteLine($"Вы сделали {schetchikOplat} оплат, Ваш долг {sumDolga} не погашен, остаток долга {ostatokDolga}");
                    Console.Write($"У Вас осталось допустимых платежей: {ostKolichPlategey} из максимально возможных {kolichPlategey}\nПродолжать погашение? y/n:");
                    Prodolg:
                    string hz = Convert.ToString(Console.ReadLine());
                    switch (hz)
                    {
                        case ("y"):
                            {
                                if (schetchikOplat >= kolichPlategey)
                                {
                                    continue;
                                }
                                else
                                {
                                    int ocherednoyPlateg = schetchikOplat + 1;
                                    Console.WriteLine("Вы продолжаете платить, выезд коллекторов отменен!!! :)");
                                    Console.Write($"Введите сумму следующего ({ocherednoyPlateg}-го) платежа: ");
                                    sumOplati += int.Parse(Console.ReadLine());
                                    continue;
                                }
                            }
                        case ("n"):
                            {
                                Console.WriteLine($"Ваш долг {sumDolga} не погашен, остаток долга {ostatokDolga}");
                                Console.WriteLine($"Вы сделали {schetchikOplat} оплат из максимально возможных {kolichPlategey} оплат.");
                                Console.WriteLine("Вы отказались платить, к Вам едут коллекторы!!! :)");
                                return;
                            }
                        default:
                            {
                                Console.Write("Вы что-то не то нажали, попробуйте еще раз! y/n:");
                                goto Prodolg;
                            }
                    }

                }
            }
            while (schetchikOplat < kolichPlategey);
            Console.WriteLine($"Вы превысили количество оплат. Из максимально возможных {kolichPlategey} Вы сделали {schetchikOplat} оплат.");
            Console.WriteLine($"Ваш долг {sumDolga} не погашен, остаток долга {ostatokDolga}, к Вам едут коллекторы!!! :)");
            return;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kolichPlategey"></param>
        /// <param name="sumDolga"></param>
        static void OpredelenieKolichPlategey(ref int kolichPlategey, int sumDolga)
        {
            if ((sumDolga > 0) && (sumDolga <= 200))
            { kolichPlategey = 3; }
            else if ((sumDolga > 0) && (sumDolga <= 400))
            { kolichPlategey = 5; }
            else if ((sumDolga > 0) && (sumDolga <= 700))
            { kolichPlategey = 7; }
            else if ((sumDolga > 0) && (sumDolga <= 1500))
            { kolichPlategey = 10; }
            else
            { kolichPlategey = 15; }
        }

        static void Main(string[] args)
        {
            Console.Write("Введите сумму долга: ");
            int sumDolga = int.Parse(Console.ReadLine());
            int kolichPlategey = 0;
            OpredelenieKolichPlategey(ref kolichPlategey, sumDolga);
            Console.WriteLine($"Максимальное количество палтежей = {kolichPlategey}");


            Console.Write("Введите сумму платежа: ");
            int sumOplati = int.Parse(Console.ReadLine());

            MessageForKredit(ref sumDolga, ref sumOplati, kolichPlategey);
            for (int i = 0; i <= 5; i++)
            {
                string s = ((i == 0) || (i == 5)) ? "*******************************************************************" : " *   *   *   *   *   *   *   *   *   *   *   *   *   *   *   *   *";
                Console.WriteLine(s);
            }
            Console.WriteLine("Спасибо, что воспользовались услугами ПлеватьБанка ;-)");
            Console.ReadKey();
        }
    }
}
