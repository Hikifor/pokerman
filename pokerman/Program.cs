using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace pokerman_bot
{
    class Program
    {
        DiscordSocketClient client;
        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();
        int igroki = 0;
        bool play = false;
        SocketUser player1, player2, player3, player4, player5, player6;
        SocketUser malBlind, bolBlind;
        bool p1 = false, p2 = false, p3 = false, p4 = false, p5 = false, p6 = false;
        int p1bet = 0, p2bet = 0, p3bet = 0, p4bet = 0, p5bet = 0, p6bet = 0;
        int p1bank = 0, p2bank = 0, p3bank = 0, p4bank = 0, p5bank = 0, p6bank = 0;
        bool startgame = false;
        bool raspredC = false;
        bool raspredBlind = false;
        bool otkCard = false;
        int round = 1;
        int c1p1num, c1p2num, c1p3num, c1p4num, c1p5num, c1p6num;
        int c2p1num, c2p2num, c2p3num, c2p4num, c2p5num, c2p6num;
        int c1p1mas, c1p2mas, c1p3mas, c1p4mas, c1p5mas, c1p6mas;
        int c2p1mas, c2p2mas, c2p3mas, c2p4mas, c2p5mas, c2p6mas;
        string c1p1numt, c1p2numt, c1p3numt, c1p4numt, c1p5numt, c1p6numt;
        string c2p1numt, c2p2numt, c2p3numt, c2p4numt, c2p5numt, c2p6numt;
        string c1p1mast, c1p2mast, c1p3mast, c1p4mast, c1p5mast, c1p6mast;
        string c2p1mast, c2p2mast, c2p3mast, c2p4mast, c2p5mast, c2p6mast;
        int c1num, c2num, c3num, c4num, c5num;
        int c1mas, c2mas, c3mas, c4mas, c5mas;
        string c1numt, c2numt, c3numt, c4numt, c5numt;
        string c1mast, c2mast, c3mast, c4mast, c5mast;
        int maxBet = 0;
        SocketUser tekPlayer;



        private async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.MessageReceived += CommandsHandler;
            client.Log += Log;

            var token = "OTQ1MjUzNDkzMzc0MDc4OTg3.YhNd6g.5ZJbhhr0AtIaW8cGya5p6cQ8HAs";

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            Console.ReadLine();
        }

        private Task Log(LogMessage Msg)
        {
            Console.WriteLine(Msg.ToString());
            return Task.CompletedTask;
        }

        private Task CommandsHandler(SocketMessage Msg)
        {
            if (p1bet > maxBet) maxBet = p1bet; if (p2bet > maxBet) maxBet = p2bet; if (p3bet > maxBet) maxBet = p3bet; if (p4bet > maxBet) maxBet = p4bet; if (p5bet > maxBet) maxBet = p5bet; if (p6bet > maxBet) maxBet = p6bet;
            if (!Msg.Author.IsBot)
            {
                switch (Msg.Content)
                {
                    case "!help":
                        {
                            Msg.Channel.SendMessageAsync("Для начала игры: !start (количество игроков)");
                            break;
                        }
                    case "!start":
                        {
                            play = true;
                            break;
                        }
                }
            }/*Команды до начала игры*/
            if (!Msg.Author.IsBot)
            {
                if (play == true)
                {
                    switch (Msg.Content)
                    {
                        case "!connect":
                            {
                                if (p1 == false)
                                {
                                    player1 = Msg.Author;
                                    p1 = true;
                                    igroki++;
                                    Msg.Channel.SendMessageAsync($"'''Первый игрок: {Msg.Author.Username}'''");
                                }
                                else
                                {
                                    if (p2 == false && Msg.Author != player1)
                                    {
                                        player2 = Msg.Author;
                                        p2 = true;
                                        igroki++;
                                        Msg.Channel.SendMessageAsync($"'''Второй игрок: {Msg.Author.Username}'''");
                                    }
                                    else
                                    {
                                        if (p3 == false && Msg.Author != player1 && Msg.Author != player2)
                                        {
                                            player3 = Msg.Author;
                                            p3 = true;
                                            igroki++;
                                            Msg.Channel.SendMessageAsync($"'''Третий игрок: {Msg.Author.Username}'''");
                                        }
                                        else
                                        {
                                            if (p4 == false && Msg.Author != player1 && Msg.Author != player2 && Msg.Author != player3)
                                            {
                                                player4 = Msg.Author;
                                                p4 = true;
                                                igroki++;
                                                Msg.Channel.SendMessageAsync($"'''Четвёртый игрок: {Msg.Author.Username}'''");
                                            }
                                            else
                                            {
                                                if (p5 == false && Msg.Author != player1 && Msg.Author != player2 && Msg.Author != player3 && Msg.Author != player4)
                                                {
                                                    player5 = Msg.Author;
                                                    p5 = true;
                                                    igroki++;
                                                    Msg.Channel.SendMessageAsync($"'''Пятый игрок: {Msg.Author.Username}'''");
                                                }
                                                else
                                                {
                                                    if (p6 == false && Msg.Author != player1 && Msg.Author != player2 && Msg.Author != player3 && Msg.Author != player4 && Msg.Author != player5)
                                                    {
                                                        player6 = Msg.Author;
                                                        p6 = true;
                                                        igroki++;
                                                        Msg.Channel.SendMessageAsync($"'''Шестой игрок: {Msg.Author.Username}'''");
                                                    }
                                                    else
                                                        Msg.Channel.SendMessageAsync($"'''Стол укомплектован'''");
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        case "!bank100":
                            {
                                p1bank = 100; p2bank = 100; p3bank = 100; p4bank = 100; p5bank = 100; p6bank = 100;
                                break;
                            }
                        case "!bank1000":
                            {
                                p1bank = 1000; p2bank = 1000; p3bank = 1000; p4bank = 1000; p5bank = 1000; p6bank = 1000;
                                break;
                            }
                        case "!bank10000":
                            {
                                p1bank = 10000; p2bank = 10000; p3bank = 10000; p4bank = 10000; p5bank = 10000; p6bank = 10000;
                                break;
                            }
                        case "!play":
                            {
                                if (igroki >= 3 && p1bank != 0)
                                {
                                    startgame = true;
                                }
                                else Msg.Channel.SendMessageAsync($"'''Дождитесь хотя бы трёх игроков или объевите размер банка'''");
                                break;
                            }
                    }
                }
            }/*предварительные настройки*/
            if (!Msg.Author.IsBot && startgame == true)
            {
                if (p4 == false)
                {
                    p4bank = 0;
                    p5bank = 0;
                    p6bank = 0;
                    igroki = 3;
                }
                if (p5 == false)
                {
                    p5bank = 0;
                    p6bank = 0;
                    igroki = 4;
                }
                if (p6 == false)
                {
                    p6bank = 0;
                    igroki = 5;
                }
                Msg.Channel.SendMessageAsync($"Игра начинается... Раунд {round}");
                for (int i = 0; i < igroki; i++)
                {
                    if (i == 0)
                    {
                        Random rnd = new Random();
                        c1p1num = rnd.Next(1, 12);
                        c2p1num = rnd.Next(1, 12);
                        c1p1mas = rnd.Next(1, 4);
                        c2p1mas = rnd.Next(1, 4);
                        switch (c1p1num)
                        {
                            case 1:
                                {
                                    c1p1numt = ":two:";
                                    break;
                                }
                            case 2:
                                {
                                    c1p1numt = ":three:";
                                    break;
                                }
                            case 3:
                                {
                                    c1p1numt = ":four:";
                                    break;
                                }
                            case 4:
                                {
                                    c1p1numt = ":five:";
                                    break;
                                }
                            case 5:
                                {
                                    c1p1numt = ":six:";
                                    break;
                                }
                            case 6:
                                {
                                    c1p1numt = ":seven:";
                                    break;
                                }
                            case 7:
                                {
                                    c1p1numt = ":eight:";
                                    break;
                                }
                            case 8:
                                {
                                    c1p1numt = ":nine:";
                                    break;
                                }
                            case 9:
                                {
                                    c1p1numt = ":keycap_ten:";
                                    break;
                                }
                            case 10:
                                {
                                    c1p1numt = ":regional_indicator_b:";
                                    break;
                                }
                            case 11:
                                {
                                    c1p1numt = ":regional_indicator_q:";
                                    break;
                                }
                            case 12:
                                {
                                    c1p1numt = ":regional_indicator_k:";
                                    break;
                                }
                        }
                        switch (c2p1num)
                        {
                            case 1:
                                {
                                    c2p1numt = ":two:";
                                    break;
                                }
                            case 2:
                                {
                                    c2p1numt = ":three:";
                                    break;
                                }
                            case 3:
                                {
                                    c2p1numt = ":four:";
                                    break;
                                }
                            case 4:
                                {
                                    c2p1numt = ":five:";
                                    break;
                                }
                            case 5:
                                {
                                    c2p1numt = ":six:";
                                    break;
                                }
                            case 6:
                                {
                                    c2p1numt = ":seven:";
                                    break;
                                }
                            case 7:
                                {
                                    c2p1numt = ":eight:";
                                    break;
                                }
                            case 8:
                                {
                                    c2p1numt = ":nine:";
                                    break;
                                }
                            case 9:
                                {
                                    c2p1numt = ":keycap_ten:";
                                    break;
                                }
                            case 10:
                                {
                                    c2p1numt = ":regional_indicator_b:";
                                    break;
                                }
                            case 11:
                                {
                                    c2p1numt = ":regional_indicator_q:";
                                    break;
                                }
                            case 12:
                                {
                                    c2p1numt = ":regional_indicator_k:";
                                    break;
                                }
                        }
                        switch (c1p1mas)
                        {
                            case 1:
                                {
                                    c1p1mast = ":spades:";
                                    break;
                                }
                            case 2:
                                {
                                    c1p1mast = ":clubs:";
                                    break;
                                }
                            case 3:
                                {
                                    c1p1mast = ":hearts:";
                                    break;
                                }
                            case 4:
                                {
                                    c1p1mast = ":diamonds:";
                                    break;
                                }
                        }
                        switch (c2p1mas)
                        {
                            case 1:
                                {
                                    c2p1mast = ":spades:";
                                    break;
                                }
                            case 2:
                                {
                                    c2p1mast = ":clubs:";
                                    break;
                                }
                            case 3:
                                {
                                    c2p1mast = ":hearts:";
                                    break;
                                }
                            case 4:
                                {
                                    c2p1mast = ":diamonds:";
                                    break;
                                }
                        }
                        player1.SendMessageAsync($"Карта 1: {c1p1numt} {c1p1mast}");
                        player1.SendMessageAsync($"Карта 2: {c2p1numt} {c2p1mast}");
                    }
                    if (i == 1)
                    {
                        Random rnd = new Random();
                        c1p2num = rnd.Next(1, 12);
                        c2p2num = rnd.Next(1, 12);
                        c1p2mas = rnd.Next(1, 4);
                        c2p2mas = rnd.Next(1, 4);
                        switch (c1p2num)
                        {
                            case 1:
                                {
                                    c1p2numt = ":two:";
                                    break;
                                }
                            case 2:
                                {
                                    c1p2numt = ":three:";
                                    break;
                                }
                            case 3:
                                {
                                    c1p2numt = ":four:";
                                    break;
                                }
                            case 4:
                                {
                                    c1p2numt = ":five:";
                                    break;
                                }
                            case 5:
                                {
                                    c1p2numt = ":six:";
                                    break;
                                }
                            case 6:
                                {
                                    c1p2numt = ":seven:";
                                    break;
                                }
                            case 7:
                                {
                                    c1p2numt = ":eight:";
                                    break;
                                }
                            case 8:
                                {
                                    c1p2numt = ":nine:";
                                    break;
                                }
                            case 9:
                                {
                                    c1p2numt = ":keycap_ten:";
                                    break;
                                }
                            case 10:
                                {
                                    c1p2numt = ":regional_indicator_b:";
                                    break;
                                }
                            case 11:
                                {
                                    c1p2numt = ":regional_indicator_q:";
                                    break;
                                }
                            case 12:
                                {
                                    c1p2numt = ":regional_indicator_k:";
                                    break;
                                }
                        }
                        switch (c2p2num)
                        {
                            case 1:
                                {
                                    c2p2numt = ":two:";
                                    break;
                                }
                            case 2:
                                {
                                    c2p2numt = ":three:";
                                    break;
                                }
                            case 3:
                                {
                                    c2p2numt = ":four:";
                                    break;
                                }
                            case 4:
                                {
                                    c2p2numt = ":five:";
                                    break;
                                }
                            case 5:
                                {
                                    c2p2numt = ":six:";
                                    break;
                                }
                            case 6:
                                {
                                    c2p2numt = ":seven:";
                                    break;
                                }
                            case 7:
                                {
                                    c2p2numt = ":eight:";
                                    break;
                                }
                            case 8:
                                {
                                    c2p2numt = ":nine:";
                                    break;
                                }
                            case 9:
                                {
                                    c2p2numt = ":keycap_ten:";
                                    break;
                                }
                            case 10:
                                {
                                    c2p2numt = ":regional_indicator_b:";
                                    break;
                                }
                            case 11:
                                {
                                    c2p2numt = ":regional_indicator_q:";
                                    break;
                                }
                            case 12:
                                {
                                    c2p2numt = ":regional_indicator_k:";
                                    break;
                                }
                        }
                        switch (c1p2mas)
                        {
                            case 1:
                                {
                                    c1p2mast = ":spades:";
                                    break;
                                }
                            case 2:
                                {
                                    c1p2mast = ":clubs:";
                                    break;
                                }
                            case 3:
                                {
                                    c1p2mast = ":hearts:";
                                    break;
                                }
                            case 4:
                                {
                                    c1p2mast = ":diamonds:";
                                    break;
                                }
                        }
                        switch (c2p2mas)
                        {
                            case 1:
                                {
                                    c2p2mast = ":spades:";
                                    break;
                                }
                            case 2:
                                {
                                    c2p2mast = ":clubs:";
                                    break;
                                }
                            case 3:
                                {
                                    c2p2mast = ":hearts:";
                                    break;
                                }
                            case 4:
                                {
                                    c2p2mast = ":diamonds:";
                                    break;
                                }
                        }
                        player2.SendMessageAsync($"Карта 1: {c1p2numt} {c1p2mast}");
                        player2.SendMessageAsync($"Карта 2: {c2p2numt} {c2p2mast}");
                    }
                    if (i == 2)
                    {
                        Random rnd = new Random();
                        c1p3num = rnd.Next(1, 12);
                        c2p3num = rnd.Next(1, 12);
                        c1p3mas = rnd.Next(1, 4);
                        c2p3mas = rnd.Next(1, 4);
                        switch (c1p3num)
                        {
                            case 1:
                                {
                                    c1p3numt = ":two:";
                                    break;
                                }
                            case 2:
                                {
                                    c1p3numt = ":three:";
                                    break;
                                }
                            case 3:
                                {
                                    c1p3numt = ":four:";
                                    break;
                                }
                            case 4:
                                {
                                    c1p3numt = ":five:";
                                    break;
                                }
                            case 5:
                                {
                                    c1p3numt = ":six:";
                                    break;
                                }
                            case 6:
                                {
                                    c1p3numt = ":seven:";
                                    break;
                                }
                            case 7:
                                {
                                    c1p3numt = ":eight:";
                                    break;
                                }
                            case 8:
                                {
                                    c1p3numt = ":nine:";
                                    break;
                                }
                            case 9:
                                {
                                    c1p3numt = ":keycap_ten:";
                                    break;
                                }
                            case 10:
                                {
                                    c1p3numt = ":regional_indicator_b:";
                                    break;
                                }
                            case 11:
                                {
                                    c1p3numt = ":regional_indicator_q:";
                                    break;
                                }
                            case 12:
                                {
                                    c1p3numt = ":regional_indicator_k:";
                                    break;
                                }
                        }
                        switch (c2p3num)
                        {
                            case 1:
                                {
                                    c2p3numt = ":two:";
                                    break;
                                }
                            case 2:
                                {
                                    c2p3numt = ":three:";
                                    break;
                                }
                            case 3:
                                {
                                    c2p3numt = ":four:";
                                    break;
                                }
                            case 4:
                                {
                                    c2p3numt = ":five:";
                                    break;
                                }
                            case 5:
                                {
                                    c2p3numt = ":six:";
                                    break;
                                }
                            case 6:
                                {
                                    c2p3numt = ":seven:";
                                    break;
                                }
                            case 7:
                                {
                                    c2p3numt = ":eight:";
                                    break;
                                }
                            case 8:
                                {
                                    c2p3numt = ":nine:";
                                    break;
                                }
                            case 9:
                                {
                                    c2p3numt = ":keycap_ten:";
                                    break;
                                }
                            case 10:
                                {
                                    c2p3numt = ":regional_indicator_b:";
                                    break;
                                }
                            case 11:
                                {
                                    c2p3numt = ":regional_indicator_q:";
                                    break;
                                }
                            case 12:
                                {
                                    c2p3numt = ":regional_indicator_k:";
                                    break;
                                }
                        }
                        switch (c1p3mas)
                        {
                            case 1:
                                {
                                    c1p3mast = ":spades:";
                                    break;
                                }
                            case 2:
                                {
                                    c1p3mast = ":clubs:";
                                    break;
                                }
                            case 3:
                                {
                                    c1p3mast = ":hearts:";
                                    break;
                                }
                            case 4:
                                {
                                    c1p3mast = ":diamonds:";
                                    break;
                                }
                        }
                        switch (c2p3mas)
                        {
                            case 1:
                                {
                                    c2p3mast = ":spades:";
                                    break;
                                }
                            case 2:
                                {
                                    c2p3mast = ":clubs:";
                                    break;
                                }
                            case 3:
                                {
                                    c2p3mast = ":hearts:";
                                    break;
                                }
                            case 4:
                                {
                                    c2p3mast = ":diamonds:";
                                    break;
                                }
                        }
                        player3.SendMessageAsync($"Карта 1: {c1p3numt} {c1p3mast}");
                        player3.SendMessageAsync($"Карта 2: {c2p3numt} {c2p3mast}");
                    }
                    if (i == 3)
                    {
                        Random rnd = new Random();
                        c1p4num = rnd.Next(1, 12);
                        c2p4num = rnd.Next(1, 12);
                        c1p4mas = rnd.Next(1, 4);
                        c2p4mas = rnd.Next(1, 4);
                        switch (c1p4num)
                        {
                            case 1:
                                {
                                    c1p4numt = ":two:";
                                    break;
                                }
                            case 2:
                                {
                                    c1p4numt = ":three:";
                                    break;
                                }
                            case 3:
                                {
                                    c1p4numt = ":four:";
                                    break;
                                }
                            case 4:
                                {
                                    c1p4numt = ":five:";
                                    break;
                                }
                            case 5:
                                {
                                    c1p4numt = ":six:";
                                    break;
                                }
                            case 6:
                                {
                                    c1p4numt = ":seven:";
                                    break;
                                }
                            case 7:
                                {
                                    c1p4numt = ":eight:";
                                    break;
                                }
                            case 8:
                                {
                                    c1p4numt = ":nine:";
                                    break;
                                }
                            case 9:
                                {
                                    c1p4numt = ":keycap_ten:";
                                    break;
                                }
                            case 10:
                                {
                                    c1p4numt = ":regional_indicator_b:";
                                    break;
                                }
                            case 11:
                                {
                                    c1p4numt = ":regional_indicator_q:";
                                    break;
                                }
                            case 12:
                                {
                                    c1p4numt = ":regional_indicator_k:";
                                    break;
                                }
                        }
                        switch (c2p4num)
                        {
                            case 1:
                                {
                                    c2p4numt = ":two:";
                                    break;
                                }
                            case 2:
                                {
                                    c2p4numt = ":three:";
                                    break;
                                }
                            case 3:
                                {
                                    c2p4numt = ":four:";
                                    break;
                                }
                            case 4:
                                {
                                    c2p4numt = ":five:";
                                    break;
                                }
                            case 5:
                                {
                                    c2p4numt = ":six:";
                                    break;
                                }
                            case 6:
                                {
                                    c2p4numt = ":seven:";
                                    break;
                                }
                            case 7:
                                {
                                    c2p4numt = ":eight:";
                                    break;
                                }
                            case 8:
                                {
                                    c2p4numt = ":nine:";
                                    break;
                                }
                            case 9:
                                {
                                    c2p4numt = ":keycap_ten:";
                                    break;
                                }
                            case 10:
                                {
                                    c2p4numt = ":regional_indicator_b:";
                                    break;
                                }
                            case 11:
                                {
                                    c2p4numt = ":regional_indicator_q:";
                                    break;
                                }
                            case 12:
                                {
                                    c2p4numt = ":regional_indicator_k:";
                                    break;
                                }
                        }
                        switch (c1p4mas)
                        {
                            case 1:
                                {
                                    c1p4mast = ":spades:";
                                    break;
                                }
                            case 2:
                                {
                                    c1p4mast = ":clubs:";
                                    break;
                                }
                            case 3:
                                {
                                    c1p4mast = ":hearts:";
                                    break;
                                }
                            case 4:
                                {
                                    c1p4mast = ":diamonds:";
                                    break;
                                }
                        }
                        switch (c2p4mas)
                        {
                            case 1:
                                {
                                    c2p4mast = ":spades:";
                                    break;
                                }
                            case 2:
                                {
                                    c2p4mast = ":clubs:";
                                    break;
                                }
                            case 3:
                                {
                                    c2p4mast = ":hearts:";
                                    break;
                                }
                            case 4:
                                {
                                    c2p4mast = ":diamonds:";
                                    break;
                                }
                        }
                        player4.SendMessageAsync($"Карта 1: {c1p4numt} {c1p4mast}");
                        player4.SendMessageAsync($"Карта 2: {c2p4numt} {c2p4mast}");
                    }
                    if (i == 4)
                    {
                        Random rnd = new Random();
                        c1p5num = rnd.Next(1, 12);
                        c2p5num = rnd.Next(1, 12);
                        c1p5mas = rnd.Next(1, 4);
                        c2p5mas = rnd.Next(1, 4);
                        switch (c1p5num)
                        {
                            case 1:
                                {
                                    c1p5numt = ":two:";
                                    break;
                                }
                            case 2:
                                {
                                    c1p5numt = ":three:";
                                    break;
                                }
                            case 3:
                                {
                                    c1p5numt = ":four:";
                                    break;
                                }
                            case 4:
                                {
                                    c1p5numt = ":five:";
                                    break;
                                }
                            case 5:
                                {
                                    c1p5numt = ":six:";
                                    break;
                                }
                            case 6:
                                {
                                    c1p5numt = ":seven:";
                                    break;
                                }
                            case 7:
                                {
                                    c1p5numt = ":eight:";
                                    break;
                                }
                            case 8:
                                {
                                    c1p5numt = ":nine:";
                                    break;
                                }
                            case 9:
                                {
                                    c1p5numt = ":keycap_ten:";
                                    break;
                                }
                            case 10:
                                {
                                    c1p5numt = ":regional_indicator_b:";
                                    break;
                                }
                            case 11:
                                {
                                    c1p5numt = ":regional_indicator_q:";
                                    break;
                                }
                            case 12:
                                {
                                    c1p5numt = ":regional_indicator_k:";
                                    break;
                                }
                        }
                        switch (c2p5num)
                        {
                            case 1:
                                {
                                    c2p5numt = ":two:";
                                    break;
                                }
                            case 2:
                                {
                                    c2p5numt = ":three:";
                                    break;
                                }
                            case 3:
                                {
                                    c2p5numt = ":four:";
                                    break;
                                }
                            case 4:
                                {
                                    c2p5numt = ":five:";
                                    break;
                                }
                            case 5:
                                {
                                    c2p5numt = ":six:";
                                    break;
                                }
                            case 6:
                                {
                                    c2p5numt = ":seven:";
                                    break;
                                }
                            case 7:
                                {
                                    c2p5numt = ":eight:";
                                    break;
                                }
                            case 8:
                                {
                                    c2p5numt = ":nine:";
                                    break;
                                }
                            case 9:
                                {
                                    c2p5numt = ":keycap_ten:";
                                    break;
                                }
                            case 10:
                                {
                                    c2p5numt = ":regional_indicator_b:";
                                    break;
                                }
                            case 11:
                                {
                                    c2p5numt = ":regional_indicator_q:";
                                    break;
                                }
                            case 12:
                                {
                                    c2p5numt = ":regional_indicator_k:";
                                    break;
                                }
                        }
                        switch (c1p5mas)
                        {
                            case 1:
                                {
                                    c1p5mast = ":spades:";
                                    break;
                                }
                            case 2:
                                {
                                    c1p5mast = ":clubs:";
                                    break;
                                }
                            case 3:
                                {
                                    c1p5mast = ":hearts:";
                                    break;
                                }
                            case 4:
                                {
                                    c1p5mast = ":diamonds:";
                                    break;
                                }
                        }
                        switch (c2p5mas)
                        {
                            case 1:
                                {
                                    c2p5mast = ":spades:";
                                    break;
                                }
                            case 2:
                                {
                                    c2p5mast = ":clubs:";
                                    break;
                                }
                            case 3:
                                {
                                    c2p5mast = ":hearts:";
                                    break;
                                }
                            case 4:
                                {
                                    c2p5mast = ":diamonds:";
                                    break;
                                }
                        }
                        player5.SendMessageAsync($"Карта 1: {c1p5numt} {c1p5mast}");
                        player5.SendMessageAsync($"Карта 2: {c2p5numt} {c2p5mast}");
                    }
                    if (i == 5)
                    {
                        Random rnd = new Random();
                        c1p6num = rnd.Next(1, 12);
                        c2p6num = rnd.Next(1, 12);
                        c1p6mas = rnd.Next(1, 4);
                        c2p6mas = rnd.Next(1, 4);
                        switch (c1p6num)
                        {
                            case 1:
                                {
                                    c1p6numt = ":two:";
                                    break;
                                }
                            case 2:
                                {
                                    c1p6numt = ":three:";
                                    break;
                                }
                            case 3:
                                {
                                    c1p6numt = ":four:";
                                    break;
                                }
                            case 4:
                                {
                                    c1p6numt = ":five:";
                                    break;
                                }
                            case 5:
                                {
                                    c1p6numt = ":six:";
                                    break;
                                }
                            case 6:
                                {
                                    c1p6numt = ":seven:";
                                    break;
                                }
                            case 7:
                                {
                                    c1p6numt = ":eight:";
                                    break;
                                }
                            case 8:
                                {
                                    c1p6numt = ":nine:";
                                    break;
                                }
                            case 9:
                                {
                                    c1p6numt = ":keycap_ten:";
                                    break;
                                }
                            case 10:
                                {
                                    c1p6numt = ":regional_indicator_b:";
                                    break;
                                }
                            case 11:
                                {
                                    c1p6numt = ":regional_indicator_q:";
                                    break;
                                }
                            case 12:
                                {
                                    c1p6numt = ":regional_indicator_k:";
                                    break;
                                }
                        }
                        switch (c2p6num)
                        {
                            case 1:
                                {
                                    c2p6numt = ":two:";
                                    break;
                                }
                            case 2:
                                {
                                    c2p6numt = ":three:";
                                    break;
                                }
                            case 3:
                                {
                                    c2p6numt = ":four:";
                                    break;
                                }
                            case 4:
                                {
                                    c2p6numt = ":five:";
                                    break;
                                }
                            case 5:
                                {
                                    c2p6numt = ":six:";
                                    break;
                                }
                            case 6:
                                {
                                    c2p6numt = ":seven:";
                                    break;
                                }
                            case 7:
                                {
                                    c2p6numt = ":eight:";
                                    break;
                                }
                            case 8:
                                {
                                    c2p6numt = ":nine:";
                                    break;
                                }
                            case 9:
                                {
                                    c2p6numt = ":keycap_ten:";
                                    break;
                                }
                            case 10:
                                {
                                    c2p6numt = ":regional_indicator_b:";
                                    break;
                                }
                            case 11:
                                {
                                    c2p6numt = ":regional_indicator_q:";
                                    break;
                                }
                            case 12:
                                {
                                    c2p6numt = ":regional_indicator_k:";
                                    break;
                                }
                        }
                        switch (c1p6mas)
                        {
                            case 1:
                                {
                                    c1p6mast = ":spades:";
                                    break;
                                }
                            case 2:
                                {
                                    c1p6mast = ":clubs:";
                                    break;
                                }
                            case 3:
                                {
                                    c1p6mast = ":hearts:";
                                    break;
                                }
                            case 4:
                                {
                                    c1p6mast = ":diamonds:";
                                    break;
                                }
                        }
                        switch (c2p6mas)
                        {
                            case 1:
                                {
                                    c2p6mast = ":spades:";
                                    break;
                                }
                            case 2:
                                {
                                    c2p6mast = ":clubs:";
                                    break;
                                }
                            case 3:
                                {
                                    c2p6mast = ":hearts:";
                                    break;
                                }
                            case 4:
                                {
                                    c2p6mast = ":diamonds:";
                                    break;
                                }
                        }
                        player6.SendMessageAsync($"Карта 1: {c1p6numt} {c1p6mast}");
                        player6.SendMessageAsync($"Карта 2: {c2p6numt} {c2p6mast}");
                    }
                } /*Для игроков*/

                raspredC = true;
            }/*Распределение карт*/
            if (!Msg.Author.IsBot && raspredC == true)
            {
                malBlind = player1;
                bolBlind = player2;
                if (p1bank == 100)
                {
                    if (malBlind == player1)
                    {
                        p1bet = 1;
                        p2bet = 2;
                    }
                    if (malBlind == player2)
                    {
                        p2bet = 1;
                        p3bet = 2;
                    }
                    if (malBlind == player3)
                    {
                        p3bet = 1;
                        if (igroki > 3) p4bet = 2;
                        else p1bet = 2;
                    }
                    if (malBlind == player4)
                    {
                        p4bet = 1;
                        if (igroki > 4) p5bet = 2;
                        else p1bet = 2;
                    }
                    if (malBlind == player5)
                    {
                        p5bet = 1;
                        if (igroki > 5) p6bet = 2;
                        else p1bet = 2;
                    }
                    if (malBlind == player6)
                    {
                        p6bet = 1;
                        p1bet = 2;
                    }
                }
                if (p1bank == 1000)
                {
                    if (malBlind == player1)
                    {
                        p1bet = 10;
                        p2bet = 20;
                    }
                    if (malBlind == player2)
                    {
                        p2bet = 10;
                        p3bet = 20;
                    }
                    if (malBlind == player3)
                    {
                        p3bet = 10;
                        if (igroki > 3) p4bet = 20;
                        else p1bet = 20;
                    }
                    if (malBlind == player4)
                    {
                        p4bet = 10;
                        if (igroki > 4) p5bet = 20;
                        else p1bet = 20;
                    }
                    if (malBlind == player5)
                    {
                        p5bet = 10;
                        if (igroki > 5) p6bet = 20;
                        else p1bet = 20;
                    }
                    if (malBlind == player6)
                    {
                        p6bet = 10;
                        p1bet = 20;
                    }
                }
                if (p1bank == 10000)
                {
                    if (malBlind == player1)
                    {
                        p1bet = 100;
                        p2bet = 200;
                    }
                    if (malBlind == player2)
                    {
                        p2bet = 100;
                        p3bet = 200;
                    }
                    if (malBlind == player3)
                    {
                        p3bet = 100;
                        if (igroki > 3) p4bet = 200;
                        else p1bet = 200;
                    }
                    if (malBlind == player4)
                    {
                        p4bet = 100;
                        if (igroki > 4) p5bet = 200;
                        else p1bet = 200;
                    }
                    if (malBlind == player5)
                    {
                        p5bet = 100;
                        if (igroki > 5) p6bet = 200;
                        else p1bet = 200;
                    }
                    if (malBlind == player6)
                    {
                        p6bet = 100;
                        p1bet = 200;
                    }
                }

                raspredBlind = true;
            }/*Определение Блайнда*/
            if (!Msg.Author.IsBot && raspredBlind == true)
            {
                SocketMessage stavki;

                if (bolBlind == player1) tekPlayer = player2;
                if (bolBlind == player2) tekPlayer = player3;
                if (bolBlind == player3)
                {
                    if (igroki == 3) tekPlayer = player1;
                    else tekPlayer = player4;
                }
                if (bolBlind == player4)
                {
                    if (igroki == 4) tekPlayer = player1;
                    else tekPlayer = player5;
                }
                if (bolBlind == player5)
                {
                    if (igroki == 5) tekPlayer = player1;
                    else tekPlayer = player6;
                }
                if (bolBlind == player6) tekPlayer = player1;

                Msg.Channel.SendMessageAsync($"1 player bet: {p1bet}; 2 player bet: {p2bet}; 3 player bet: {p3bet}; 4 player bet: {p4bet}; 5 player bet: {p5bet}; 6 player bet: {p6bet};");
                for (int kolvoStavok = 0; kolvoStavok < igroki; kolvoStavok++)
                {
                    tekPlayer.SendMessageAsync($"Хотите уровнять или поднять? Текущая макс. ставка {maxBet}");
                    do
                    {
                        switch (Msg.Content)
                        {
                            case "!call":
                                {
                                    if (tekPlayer == player1) p1bet = maxBet;
                                    if (tekPlayer == player2) p2bet = maxBet;
                                    if (tekPlayer == player3) p3bet = maxBet;
                                    if (tekPlayer == player4) p4bet = maxBet;
                                    if (tekPlayer == player5) p5bet = maxBet;
                                    if (tekPlayer == player6) p6bet = maxBet;
                                    break;
                                }
                            case "!raise1":
                                {
                                    if (tekPlayer == player1) p1bet = maxBet + 1;
                                    if (tekPlayer == player2) p2bet = maxBet + 1;
                                    if (tekPlayer == player3) p3bet = maxBet + 1;
                                    if (tekPlayer == player4) p4bet = maxBet + 1;
                                    if (tekPlayer == player5) p5bet = maxBet + 1;
                                    if (tekPlayer == player6) p6bet = maxBet + 1;
                                    break;
                                }
                            case "!raise5":
                                {
                                    if (tekPlayer == player1) p1bet = maxBet + 5;
                                    if (tekPlayer == player2) p2bet = maxBet + 5;
                                    if (tekPlayer == player3) p3bet = maxBet + 5;
                                    if (tekPlayer == player4) p4bet = maxBet + 5;
                                    if (tekPlayer == player5) p5bet = maxBet + 5;
                                    if (tekPlayer == player6) p6bet = maxBet + 5;
                                    break;
                                }
                            case "!raise10":
                                {
                                    if (tekPlayer == player1) p1bet = maxBet + 10;
                                    if (tekPlayer == player2) p2bet = maxBet + 10;
                                    if (tekPlayer == player3) p3bet = maxBet + 10;
                                    if (tekPlayer == player4) p4bet = maxBet + 10;
                                    if (tekPlayer == player5) p5bet = maxBet + 10;
                                    if (tekPlayer == player6) p6bet = maxBet + 10;
                                    break;
                                }
                            case "!raise25":
                                {
                                    if (tekPlayer == player1) p1bet = maxBet + 25;
                                    if (tekPlayer == player2) p2bet = maxBet + 25;
                                    if (tekPlayer == player3) p3bet = maxBet + 25;
                                    if (tekPlayer == player4) p4bet = maxBet + 25;
                                    if (tekPlayer == player5) p5bet = maxBet + 25;
                                    if (tekPlayer == player6) p6bet = maxBet + 25;
                                    break;
                                }
                            case "!fold":
                                {
                                    if (tekPlayer == player1) p1bank = p1bank - p1bet;
                                    if (tekPlayer == player2) p2bank = p2bank - p2bet;
                                    if (tekPlayer == player3) p3bank = p3bank - p3bet;
                                    if (tekPlayer == player4) p4bank = p4bank - p4bet;
                                    if (tekPlayer == player5) p5bank = p5bank - p5bet;
                                    if (tekPlayer == player6) p6bank = p6bank - p6bet;
                                    break;
                                }
                            case "!AllIn":
                                {
                                    if (tekPlayer == player1) p1bet = p1bank;
                                    if (tekPlayer == player2) p2bet = p2bank;
                                    if (tekPlayer == player3) p3bet = p3bank;
                                    if (tekPlayer == player4) p4bet = p4bank;
                                    if (tekPlayer == player5) p5bet = p5bank;
                                    if (tekPlayer == player6) p6bet = p6bank;
                                    break;
                                }
                        }
                        if (tekPlayer == player1) tekPlayer = player2;
                        if (tekPlayer == player2) tekPlayer = player3;
                        if (tekPlayer == player3)
                        {
                            if (igroki == 3) tekPlayer = player1;
                            else tekPlayer = player4;
                        }
                        if (tekPlayer == player4)
                        {
                            if (igroki == 4) tekPlayer = player1;
                            else tekPlayer = player5;
                        }
                        if (tekPlayer == player5)
                        {
                            if (igroki == 5) tekPlayer = player1;
                            else tekPlayer = player6;
                        }
                        if (tekPlayer == player6) tekPlayer = player1;
                    }
                    while (p1bet == p2bet && p1bet == p3bet && p1bet == p4bet && p1bet == p5bet && p1bet == p6bet);
                    otkCard = true;
                }
            }
            return Task.CompletedTask;
        }
    }
}