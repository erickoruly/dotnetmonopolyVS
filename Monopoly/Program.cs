using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Program
    {

        static void Main(string[] args)
        {
            //Inisialisasi Card----------------------------------------------------------------------
            Card card1 = new Card("250", 250, "Player get money 250", 0);
            Card card2 = new Card("750", 750, "Player get money 750", 0);
            Card card3 = new Card("1000", 1000, "Player get money 1000", 0);
            Card card4 = new Card("1500", 1500, "Player get money 1500", 0);
            Card card5 = new Card("2500", 2500, "Player get money 2500", 0);
            List<Card> c = new List<Card>();
            c.Add(card1);
            c.Add(card2);
            c.Add(card3);
            c.Add(card4);
            c.Add(card5);
            //---------------------------------------------------------------------------------------
            //inisialisai airport
            Airport airport1 = new Airport("Incheon Airport", 250);
            Airport airport2 = new Airport("Domodedovo Airport", 250);
            Airport airport3 = new Airport("Soekarno-Hatta Airport", 250);
            Airport airport4 = new Airport("Chhatrapati Shivaji Airport", 250);
            //---------------------------------------------------------------------------------------
            //Inisialisasi dll
            Start start = new Start();
            Chest chest1 = new Chest("Chest1", 0, c);
            Chest chest2 = new Chest("Chest2", 0, c);
            Chest chest3 = new Chest("Chest3", 0, c);
            Chest chest4 = new Chest("Chest4", 0, c);
            Jail jail = new Jail();
            GoToJail toJail = new GoToJail();
            FreeParking freePark = new FreeParking();
            //---------------------------------------------------------------------------------------

            //Insialisai country
            Country america = new Country("America", 1700);
            Country mexico = new Country("Mexico", 500);
            Country indo = new Country("Indonesia", 3500);
            Country china = new Country("China", 760);
            Country portugal = new Country("Portugal", 550);
            Country japan = new Country("Japan", 890);
            Country italy = new Country("Italia", 880);
            Country canada = new Country("Canada", 670);
            Country england = new Country("England", 1200);
            Country germany = new Country("Germany", 1300);
            Country sKorea = new Country("South Korea", 1500);
            Country russia = new Country("Russia", 1900);
            Country malaysia = new Country("Malaysia", 810);
            Country sweeden = new Country("Sweeden", 930);
            Country brazil = new Country("Brazil", 1000);
            Country thailand = new Country("Thailand", 770);
            //---------------------------------------------------------------------------------------

            //Inisialisasi Map-----------------------------------------------------------------------
            List<Place> map = new List<Place>();
            map.Add(start);// 1
            map.Add(canada);//2
            map.Add(chest1);//3
            map.Add(airport1);// 4
            map.Add(mexico);// 5
            map.Add(indo);// 6
            map.Add(china);// 7
            map.Add(jail);//8
            map.Add(airport2);// 9
            map.Add(america);//10
            map.Add(italy);//11
            map.Add(england);//12
            map.Add(germany);//13
            map.Add(chest2);//14
            map.Add(freePark);//15
            map.Add(sKorea);//16
            map.Add(chest3);//17
            map.Add(russia);//18
            map.Add(airport3);//19
            map.Add(sweeden);//20
            map.Add(brazil);//21
            map.Add(toJail);//22
            map.Add(malaysia);//23
            map.Add(portugal);// 24
            map.Add(japan);//25
            map.Add(chest4);//26
            map.Add(airport4);// 27
            map.Add(thailand);//28
            // 28
            //---------------------------------------------------------------------------------------

            bool next = false; // sebagai tanda untuk maju atau tidak ke step game yang selanjutnya
            int maxPlayer = 4; // jumlah maksimal player
            int playerAmount = 0; // jumlah player
            Player player1 = null;
            Player player2 = null;
            Player player3 = null;
            Player player4 = null;
            //---------------------------------------------------------------------------------------

            while (true)// step inisialisasi player
            {
                try
                {
                    Console.WriteLine("Amount of Player ??(max 4)");
                    playerAmount = Convert.ToInt32(Console.ReadLine());
                    if (playerAmount > maxPlayer)
                        throw new Exception("Amount of player is more than 4");
                    else if (playerAmount < 1)
                        throw new Exception("Amount of player number is invalid");
                    else if (playerAmount == 1)
                        throw new Exception("You can't just play by yourself");
                    else next = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (next == true)
                {
                    String temp;
                    Console.WriteLine("Player 1 Name :");
                    temp = Convert.ToString(Console.ReadLine());
                    player1 = new Player(temp);
                    if (playerAmount > 1)
                    {
                        Console.WriteLine("Player 2 Name :");
                        temp = Convert.ToString(Console.ReadLine());
                        player2 = new Player(temp);
                    }
                    if (playerAmount > 2)
                    {
                        Console.WriteLine("Player 3 Name :");
                        temp = Convert.ToString(Console.ReadLine());
                        player3 = new Player(temp);
                    }
                    if (playerAmount > 3)
                    {
                        Console.WriteLine("Player 4 Name :");
                        temp = Convert.ToString(Console.ReadLine());
                        player4 = new Player(temp);
                    }
                    break;
                }
            }
            //---------------------------------------------------------------------------------------
            Dice dadu1 = new Dice(); // inisialisasi dadu 1
            Dice dadu2 = new Dice(); // inisialisasi dadu 2
            int roll = 'c'; //variabel untuk menentukan apakah player akan melakukan roll atau skip
            int turn = 1;
            bool rollAgain = false;
            int playerAlive = playerAmount;
            int step;
            bool waitingTurn = false;
            while (true)//roll turn
            {
                //Console.WriteLine("TEST : number of card : {0}", c.Count);
                Console.WriteLine("======================PLayer Money=============================");
                if (playerAmount > 0) ShowPlayerMoney(player1, 1);
                if (playerAmount > 1) ShowPlayerMoney(player2, 2);
                if (playerAmount > 2) ShowPlayerMoney(player3, 3);
                if (playerAmount > 3) ShowPlayerMoney(player4, 4);
                Console.WriteLine("===============================================================");
                step = 0;
                Console.WriteLine("------------------------------------------------------------");
                if (turn == 1)
                {
                    Console.WriteLine("PLAYER 1");
                    if (player1.CheckPlace() == true)
                    {
                        player1.SellPlaces();
                    }
                    if (player1.Arrest > 0)
                    {
                        Console.WriteLine("{0} turn left.", player1.Arrest);
                        player1.Arrest--;
                        waitingTurn = true;
                    }
                }
                else if (turn == 2)
                {
                    Console.WriteLine("PLAYER 2");
                    if (player2.CheckPlace() == true)
                    {
                        player2.SellPlaces();
                    }
                    if (player2.Arrest > 0)
                    {
                        Console.WriteLine("{0} turn left.", player2.Arrest);
                        player2.Arrest--;
                        waitingTurn = true;
                    }
                }
                else if (turn == 3)
                {
                    Console.WriteLine("PLAYER 3");
                    if (player3.CheckPlace() == true)
                    {
                        player3.SellPlaces();
                    }
                    if (player3.Arrest > 0)
                    {
                        Console.WriteLine("{0} turn left.", player3.Arrest);
                        player3.Arrest--;
                        waitingTurn = true;
                    }
                }
                else if (turn == 4)
                {
                    Console.WriteLine("PLAYER 4");
                    if (player4.CheckPlace() == true)
                    {
                        player4.SellPlaces();
                    }
                    if (player4.Arrest > 0)
                    {
                        Console.WriteLine("{0} turn left.", player4.Arrest);
                        player4.Arrest--;
                        waitingTurn = true;
                    }
                }
                if (!waitingTurn)
                {
                    Console.WriteLine("Roll Dice or skip ?? (r/s)"); // menentukan apakah akan roll atau skip
                    roll = Convert.ToChar(Console.ReadLine());
                    if (roll != 'r' && roll != 's') // jika input salah, ulang giliran
                    {
                        Console.WriteLine("Wrong Input!!!");
                        rollAgain = true;
                    }
                    if (roll == 's') // options jika melakukan skip 
                    {
                        char skip = 's';
                        Console.WriteLine("You want to skip(y/n)??"); // memastikan apakah player akan skip turn
                        skip = Convert.ToChar(Console.ReadLine());
                        if (skip != 'y') rollAgain = true;
                    }
                    if (roll == 'r')// options jika melakukan roll
                    {
                        int temp1, temp2;
                        temp1 = dadu1.Roll();
                        temp2 = dadu2.Roll();
                        Console.WriteLine("first dice : {0}", temp1);
                        Console.WriteLine("second dice : {0}", temp2);
                        if (temp1 == temp2) rollAgain = true;
                        if (turn == 1 && player1.Alive == true)
                        {
                            player1.Position += (temp1 + temp2);
                            if (player1.Position > 28)
                            {
                                player1.Position -= 28;
                                player1.Money += 250;
                            }
                            Console.WriteLine("player position : {0}", player1.Position);
                            step = player1.Position;
                            map[player1.Position - 1].Effect(player1);
                        }
                        else if (turn == 2 && player2.Alive == true)
                        {
                            player2.Position += (temp1 + temp2);
                            if (player2.Position > 28)
                            {
                                player2.Position -= 28;
                                player2.Money += 250;
                            }
                            Console.WriteLine("player position : {0}", player2.Position);
                            step = player2.Position;
                            map[player2.Position - 1].Effect(player2);
                        }
                        else if (turn == 3 && player3.Alive == true)
                        {
                            player3.Position += (temp1 + temp2);
                            if (player3.Position > 28)
                            {
                                player3.Position -= 28;
                                player3.Money += 250;
                            }
                            Console.WriteLine("player position : {0}", player3.Position);
                            step = player3.Position;
                            map[player3.Position - 1].Effect(player3);
                        }
                        else if (turn == 4 && player4.Alive == true)
                        {
                            player4.Position += (temp1 + temp2);
                            if (player4.Position > 28)
                            {
                                player4.Position -= 28;
                                player4.Money += 250;
                            }
                            Console.WriteLine("player position : {0}", player4.Position);
                            step = player4.Position;
                            map[player4.Position - 1].Effect(player4);
                        }
                    }
                }
                //mengecek jumlah player yang sudah kalah
                if (playerAmount > 0 && player1.CheckMoney() == false)
                {
                    playerAlive--;
                    player1.Alive = false;
                }
                if (playerAmount > 1 && player2.CheckMoney() == false)
                {
                    playerAlive--;
                    player2.Alive = false;
                }
                if (playerAmount > 3 && player3.CheckMoney() == false)
                {
                    playerAlive--;
                    player3.Alive = false;
                }
                if (playerAmount > 4 && player4.CheckMoney() == false)
                {
                    playerAlive--;
                    player4.Alive = false;
                }
                //---------------------------------------------------------------------------------------

                if (playerAlive == 1)
                {
                    Console.WriteLine("We have a winner");
                    break;
                }

                //pergantian turn
                if (turn < playerAmount && rollAgain == false) turn++;
                else if (turn == playerAmount && rollAgain == false) turn = 1;
                rollAgain = false;
                waitingTurn = false;
                //---------------------------------------------------------------------------------------

             }
            Console.ReadLine();
        }

        static void ShowPlayerMoney(Player p, int i)
        {
            Console.WriteLine("Player {0}({1}) money is {2}",i, p.Name, p.Money);
        }
    }
}
