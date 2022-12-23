namespace CavaCipherChallenge
{
    using System;
    
    internal class Program
    {
        private const String amazonKey = "1t2est";
        private static String ris1="";
        private static String ris2="";
        private static String ris2Alt = "";
        private static String ris2AltAlt = "";
        private static String ris3="";

        public static void rispostaEsatta()
        {
            Console.WriteLine("esattto");
            /*
            */
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("======================================================");
            Console.WriteLine("======================================================");
        }

        public static void Main(string[] args)
        {
            
            #region InizializzazioneConsole
            Console.ForegroundColor = ConsoleColor.Green; //color;
            Console.WriteLine("╔╦═╦═══════╦═╦╦═╦╦══════╦═╦╦══╦╦╦════════╗");
            Console.WriteLine("║║╔╬═╦╦╦═╗ ║╔╬╬═╣╚╦═╦═╗ ║╔╣╚╦═╣║╠═╦═╦═╦═╗║");
            Console.WriteLine("║║╚╬╝║║╠╝║ ║╚╣║║║║║╩╣╠╝ ║╚╣║╠╝║║║╩╣║║║║╩╣║");
            Console.WriteLine("║╚═╩═╩═╩═╝ ╚═╩╣╔╩╩╩═╩╝  ╚═╩╩╩═╩╩╩═╩╩╬═╠═╝║");
            Console.WriteLine("╚═════════════╩╩════════════════════╩═╩══╝");
            Console.WriteLine();

            //inizializzazione risposta domanda 1
            ris1 = "1492";
            
            //inizializzazione risposta alla domanda 2
            foreach (char item in ris1)
            {
                ris2 += "00"+Convert.ToString((int)item,2)+" ";
                ris2AltAlt += "00" + Convert.ToString((int) item, 2);
            }
            ris2Alt = Convert.ToString(int.Parse(ris1), 2);
            //Console.WriteLine(ris2);
            
            //inizializzazione operatore chiave alla domanda 3
            String operatoreAlt = "";
            String operatore = "";
            string tmp = amazonKey.Remove((amazonKey.Length - 1));
            foreach (char item in tmp )
            {
                String strinaForm = Convert.ToString((int) item, 2);
                if (strinaForm.Length < 8)
                {
                    string tmp2 = strinaForm;
                    //aggiungo tot zeri davanti fino ad arrivare ad 8
                    for (int i = 0; i < 8 - tmp2.Length; i++)
                    {
                        strinaForm = "0" + strinaForm;
                    }
                }
                operatoreAlt += strinaForm+" ";
                operatore += strinaForm;
            }

            //formatto la stringa ris2 per essere della lunghezza giusta
            int l = operatore.Length;
            String op1 = "";
            for (int i = 0; i < (l - ris2AltAlt.Length); i++)
            {
                op1 += "0";
            }
            op1 += ris2AltAlt;
            //print di test per vedere se le 2 stringhe hanno la stessa lunghezza
            //Console.WriteLine(op1);
            //Console.WriteLine(operatore);
            
            //calcolo la stringa di risposta 3
            for(int i=0; i<operatore.Length; i++)
            {
                ris3 += (operatore[i].Equals('1') ^ op1[i].Equals('1')) ? "1" : "0";
            }
            //Console.WriteLine(ris3);
            #endregion

            #region Challenge1
            Console.WriteLine("======================================================");
            Console.WriteLine("======================================================");
            Console.WriteLine("██▄ ███ █▄ ▄█ ███ █  █ ██▄ ███    █ █ █  █ ███");
            Console.WriteLine("█ █ █ █ █ █ █ █▄█ ██▄█ █ █ █▄█    █ █ ██▄█ █ █");
            Console.WriteLine("███ █▄█ █   █ █ █ █ ██ ███ █ █    ███ █ ██ █▄█");
            bool risposta1 = false;
            while (!risposta1)
            {
                Console.WriteLine("In quale anno è stata scoperta l'america?\n(inserisci la risposta e premi invio)");
                String x = Console.ReadLine();
                
                if (x.Contains(ris1))
                {
                    rispostaEsatta();
                    risposta1 = true;
                }
                else
                {
                    Console.WriteLine("======================================================");
                    Console.WriteLine("Tentativo errato, riprova");
                    Console.WriteLine("======================================================");
                }
            }
            #endregion

            #region Challenge2
            Console.WriteLine("██▄ ███ █▄ ▄█ ███ █  █ ██▄ ███    ██▄ █ █ ███");
            Console.WriteLine("█ █ █ █ █ █ █ █▄█ ██▄█ █ █ █▄█    █ █ █ █ █▄ ");
            Console.WriteLine("███ █▄█ █   █ █ █ █ ██ ███ █ █    ███ ███ █▄▄");
            bool risposta2 = false;
            while (!risposta2)
            {
                Console.WriteLine("I computer sono in grado di ragionare in linguaggio macchina.\nIl linguaggio macchina NON opera con calcoli in base decimale, ma che in quale base?\nPer rispondere alla domanda 2 converti la risposta della domanda 1 nella stessa base con il queale operano i computer\n(inserisci la conversione e premi invio)");
                String x = Console.ReadLine();
                
                //rendo la risposta inserita lunga quanto la chiave aggiungendo zeri in testa
                int temp = x.Length;
                for (int i = temp-1; i >0; i--)
                {
                    if (x[i].Equals(' '))
                    {
                         x = x.Substring(0,i);
                    }
                    else if (x[i].Equals('0') || x[i].Equals('1'))
                    {
                        break;
                    }
                }

                int l2 = ris2.Length;
                String op2 = "";
                for (int i = 0; i < (l2 - x.Length); i++)
                {
                    op2 += "0";
                }
                op2 += x;
                
                //rendo la risposta inserita lunga quanto la chiave aggiungendo zeri in testa
                int l3 = ris2AltAlt.Length;
                String op3 = "";
                for (int i = 0; i < (l3 - x.Length); i++)
                {
                    op3 += "0";
                }
                op3 += x;
                
                if ((op2+" ").Contains(ris2) || x.Contains(ris2Alt) || op3.Contains(ris2AltAlt))
                {
                    rispostaEsatta();
                    risposta2 = true;
                    if (x.Contains(ris2Alt))
                    {
                        Console.WriteLine("La tua risposta è corretta, hai tramutato un numero dalla base 10 alla base 2, \nperò io volevo convertissi una stringa in binario\nLa risposta che mi aspettavo era:\n"+ris2);
                    }
                    else if(op3.Contains(ris2AltAlt))
                    {
                        Console.WriteLine("La tua risposta è corretta hai convertito una stringa in binario\nLa risposta che mi aspettavo era però con la spaziatura corretta:\n"+ris2);
                    }
                }
                else
                {
                    Console.WriteLine("======================================================");
                    Console.WriteLine("Tentativo errato, riprova");
                    Console.WriteLine("======================================================");
                }
            }
            #endregion

            #region Challenge3
            Console.WriteLine("██▄ ███ █▄ ▄█ ███ █  █ ██▄ ███    ███ ███ ███");
            Console.WriteLine("█ █ █ █ █ █ █ █▄█ ██▄█ █ █ █▄█     █  ██  █▄ ");
            Console.WriteLine("███ █▄█ █   █ █ █ █ ██ ███ █ █     █  █ █ █▄▄");
            bool risposta3 = false;
            int count = 0;
            while (!risposta3)
            {
                Console.WriteLine("Utilizza la risposta alla domanda 2 e cifrala con quello che è stata definito come:\n\"l'operatore logico di cifratura perfetto\"\nCome secondo operando (chiave) per eseguire questa operazione dovrai usare:");
                Console.WriteLine(operatoreAlt);
                if (count >= 10)
                {
                    Console.WriteLine("*******************************************************");
                    Console.WriteLine("INDIZIO: il metodo di cifratura che usa l'operatore logico che stai cercando è contenuto in un metodo crittografico ideato nel 1917 ed è stato verificato come \"perfetto\" nel 1949");
                    Console.WriteLine("*******************************************************");
                }
                Console.WriteLine("(inserisci il testo cifrato e premi invio)");
                String x = Console.ReadLine();
                
                //tolgo gli spazi dalla risposta
                int temp = x.Length;
                for (int i = temp-1; i >0; i--)
                {
                    if (x[i].Equals(' '))
                    {
                        String add = "";
                        try
                        {
                            x.Substring(i + 1, x.Length - 1);
                        } catch (Exception e) { }
                        x = x.Substring(0,i)+add;
                    }
                }
                
                //rendo la risposta inserita lunga quanto la chiave aggiungendo zeri in testa
                int l2 = operatore.Length;
                String op2 = "";
                for (int i = 0; i < (l2 - x.Length); i++)
                {
                    op2 += "0";
                }
                op2 += x;

                if (op2.Contains(ris3))
                {
                    rispostaEsatta();
                    risposta3 = true;
                }
                else
                {
                    Console.WriteLine("======================================================");
                    Console.WriteLine("Tentativo errato, riprova");
                    Console.WriteLine("======================================================");
                    count++;
                }
            }
            #endregion

            #region End
            Console.WriteLine("Congratulazioni sei riuscito a superare la mia cipger challenge ecco il tuo premio:");
            Console.WriteLine("il tuo copdice amazon gift card è: "+amazonKey);
            Console.WriteLine("Sbrigati a riscattarlo prima che qualcuno sia più veloce di te :) ");
            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░█████████"); 
            Console.WriteLine("░░███████░░░░░░░░░░███▒▒▒▒▒▒▒▒███");
            Console.WriteLine("░░█▒▒▒▒▒▒█░░░░░░░███▒▒▒▒▒▒▒▒▒▒▒▒▒███");
            Console.WriteLine("░░░█▒▒▒▒▒▒█░░░░██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██");
            Console.WriteLine("░░░░█▒▒▒▒▒█░░░██▒▒▒▒▒██▒▒▒▒▒▒██▒▒▒▒▒███");
            Console.WriteLine("░░░░░█▒▒▒█░░░█▒▒▒▒▒▒████▒▒▒▒████▒▒▒▒▒▒██");
            Console.WriteLine("░░░█████████████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██");
            Console.WriteLine("░░░█▒▒▒▒▒▒▒▒▒▒▒▒█▒▒▒▒▒▒▒▒▒█▒▒▒▒▒▒▒▒▒▒▒██");
            Console.WriteLine("░██▒▒▒▒▒▒▒▒▒▒▒▒▒█▒▒▒██▒▒▒▒▒▒▒▒▒▒██▒▒▒▒██");
            Console.WriteLine("██▒▒▒███████████▒▒▒▒▒██▒▒▒▒▒▒▒▒██▒▒▒▒▒██");
            Console.WriteLine("█▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒█▒▒▒▒▒▒████████▒▒▒▒▒▒▒██");
            Console.WriteLine("██▒▒▒▒▒▒▒▒▒▒▒▒▒▒█▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██");
            Console.WriteLine("░█▒▒▒███████████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██");
            Console.WriteLine("░██▒▒▒▒▒▒▒▒▒▒████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒█");
            Console.WriteLine("░░████████████░░░█████████████████");
            #endregion

        }
    }
}