using System;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Diagnostics;

namespace TextRPG
{
    public class Item
    {
        public String Name { get; } // 아이템 이름
        public String Description { get; } // 아이템 설명
        public int Type { get; } // 아이템 타입 (무기, 방어구 등)
        public int Att { get; } // 공격력
        public int Def { get; } // 방어력
        public int Gold { get; } // 가격
        public bool IsEquipped { get; set; } // 장착 여부
        public static int Itemcount = 0; // 아이템 개수
        public Item(string name, string description, int type, int att, int def, int gold, bool isEquipped = false) // 아이템 생성자
        {
            Name = name; // 아이템 이름
            Description = description; // 아이템 설명
            Type = type; // 아이템 타입 (무기, 방어구 등)
            Att = att; // 공격력
            Def = def; // 방어력
            Gold = gold; // 가격
            IsEquipped = false; // 장착 여부 초기화
            Itemcount++; // 아이템 개수 증가
        }
    }
    
    
    

   
    // Removed from here and moved inside the Program class
    public class Player
    // 플레이어 클래스 
    {
        // 플레이어 정보 (프로퍼티)
        public string PlayerName { get; set; } //플레이어 이름
        public int Level { get; set; } //플레이어 레벨
        public string Job { get; set; } //플레이어 직업
        public int Att { get; set; } //플레이어 공격력
        public int Def { get; set; } //플레이어 방어력
        public int HP { get; set; } //플레이어 체력
        public int Gold { get; set; } //플레이어 골드



        public List<Item> Inventory { get; set; } // 플레이어 인벤토리

        public Player(string playerName) //플레이어 이름
        {
            PlayerName = playerName;
            Level = 1; //레벨 초기화
            Job = "전사"; //직업 초기화
            Att = 10; //공격력 초기화
            Def = 5; //방어력 초기화
            HP = 100; //체력 초기화
            Gold = 1500; //골드 초기화
            Inventory = new List<Item>(); //인벤토리 초기화
        }    //플레이어 생성자

        

      
    internal class Program
    {
        public static Store GameStore = new Store(); // 상점 객체 생성

        //플레이어 정보
        static int level = 1;
        static string PlayerName;
        static string Job = "전사";
        static int Att = 10;
        static int Def = 5;
        static int HP = 100;
        static int Gold = 1500;

        public class Item // 아이템 클래스
        {
            public string ItemName { get; set; } //아이템 이름
            public string ToolTip { get; set; } //아이템 설명
            public int Attack { get; set; } // 공격력
            public int Defense { get; set; } // 방어력
            public int Price { get; set; } // 아이템 가격
            public bool Purchase { get; set; } // 구매 여부
            public bool EqippedItem { get; set; } // 장착 여부
            public bool EqipItem { get; set; } // 장착 아이템 여부
    
            public Item(string itemName, string tooltip, int attack, int defense, int price, bool purchase)
            {
                ItemName = itemName;
                ToolTip = tooltip;
                Attack = attack;
                Defense = defense;
                Price = price;
                Purchase = false; // 초기 기본값, 구매 아이템 없음
                EqippedItem = false; // 장착 여부 초기화
            }
        }

        public class Store // 상점 클래스
        {
            public List<Item> Items { get; set; } // 상점 아이템 목록

            public Store() // 상점 생성자
            {
                Items = new List<Item>(); // 상점 아이템 목록 초기화
                {
                    // 아이템을 생성하고 특성 정의
                    Items.Add(new Item("나무검", "공격력 +5, 방금 벤 나무로 깍은 듯한 무기, 사용감이 적어보인다.", 5, 0, 100, false));
                    Items.Add(new Item("철검", "공격력 +10, 마을 근처 광산에서 캔 철로 만든 무기, 반짝임이 돋보인다. ", 10, 0, 200, false));
                    Items.Add(new Item("가죽갑옷", "방어력 +5, 질이 좋은 짐승의 가죽을 사용한 갑옷, 무척 빨라질 것 같다.", 0, 5, 150, false));
                    Items.Add(new Item("철갑옷", "방어력 +10, 방금 만들어낸 갑옷같다, 단단해질 것 같다.", 0, 10, 300, false));
                    Items.Add(new Item("나무방패", "방어력 +5, 방금 벤 나무로 깍은 듯한 방패, 사용감이 적어보인다.", 0, 5, 100, false));    
            
                }
            }
        }

            public class SaveGame() // 6. 게임 저장 클래스
            {

            }

        static void Main(string[] args)
            {
                Console.Write("당신의 이름을 입력하시오:");
                string playerName = Console.ReadLine(); // 유저 네임 입력하기
                PlayerName = playerName; // 이름 짓기
                Console.WriteLine();
                InitialzeStore();
                Player player = new Player(playerName); // 입력받은 이름으로 플레이어 객체 생성
                Stage stage = new Stage();
                stage.getSelect(); // 스테이지 객체 생성 및 선택 메서드 호출;

            }

        private static void InitialzeStore() // 상점 초기화
        {
            GameStore.Items = new List<Item>(); // 상점 객체 생성
            {
            new Item("나무검", "공격력 +5, 방금 벤 나무로 깍은 듯한 무기, 사용감이 적어보인다.", 5, 0, 100, false);
            new Item("철검", "공격력 +10, 마을 근처 광산에서 캔 철로 만든 무기, 반짝임이 돋보인다. ", 10, 0, 200, false);
            new Item("가죽갑옷", "방어력 +5, 질이 좋은 짐승의 가죽을 사용한 갑옷, 무척 빨라질 것 같다.", 0, 5, 150, false);
            new Item("철갑옷", "방어력 +10, 방금 만들어낸 갑옷같다, 단단해질 것 같다.", 0, 10, 300, false);
            new Item("나무방패", "방금 벤 나무로 깍은 듯한 방패, 사용감이 적어보인다.", 0, 5, 100, false);

            };
        }

        public class Stage
        {
            public void getSelect()
            {
                while (true) //선택 루프 시작
                {
                    Console.Clear();
                    Console.WriteLine($"안녕하세요,{PlayerName}님!\n");
                    Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n");
                    Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
                    Console.WriteLine();
                    Console.WriteLine("1. 상태 보기\n");
                    Console.WriteLine("2. 인벤토리\n");
                    Console.WriteLine("3. 상점\n");
                    Console.WriteLine("4. 던전 입장\n");
                    Console.WriteLine("5. 휴식하기\n");
                    Console.WriteLine("6. 게임 저장\n");
                    Console.WriteLine();
                    Console.WriteLine("원하시는 행동을 입력해주세요.\n");

                    if (!int.TryParse(Console.ReadLine(), out int selectInput)) // out = selectInput
                    {
                        continue;
                    }

                    switch (selectInput)
                    {
                        case 1:
                            PlayerInfo();
                            break;
                        case 2:
                            Inventory();
                            break;
                        case 3:
                            Store();
                            break;
                        case 4:
                            Dungeon();
                            break;
                        case 5:
                            Rest(selectInput);
                            break;
                        case 6:
                            SaveGame();
                            break;
                    }
                }
            }

            public void Store() // 3. 상점
            {
                Console.Clear();
                Console.WriteLine("[ 상점 ]\n 상점에서 아이템을 구매할 수 있습니다.\n");
                Console.WriteLine("[ 보유 골드 ]\n");
                Console.WriteLine($"Gold: {Gold} G\n");

                List<Item> items = new List<Item>
            {
                new Item("나무검", "공격력 +5, 방금 벤 나무로 깍은 듯한 무기, 사용감이 적어보인다.", 5, 0, 100, false),
                new Item("철검", "공격력 +10, 마을 근처 광산에서 캔 철로 만든 무기, 반짝임이 돋보인다. ", 10, 0, 200, false),
                new Item("가죽갑옷", "방어력 +5, 질이 좋은 짐승의 가죽을 사용한 갑옷, 무척 빨라질 것 같다.", 0, 5, 150, false),
                new Item("철갑옷", "방어력 +10, 방금 만들어낸 갑옷같다, 단단해질 것 같다.", 0, 10, 300, false)
            };
                Console.WriteLine("[ 아이템 목록 ]\n");
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {items[i].ItemName} - {items[i].ToolTip} (가격: {items[i].Price} G)");
                }

                foreach (var item in items)
                {
                    item.Purchase = false; // 구매 여부 초기화
                }


                Console.WriteLine();
                Console.WriteLine(" 원하시는 행동을 입력해주세요.\n");
                Console.WriteLine(" 0. 나가기\n 1. 아이템 구매\n ");

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int store)) // 0,1 중에 택1
                    {
                        switch (store)
                        {
                            case 0:
                                getSelect(); // 0 나가기
                                break;
                            case 1:
                                BuyItem(items); // 3-1 아이템 구매 ()안에 item 넣기
                                break;
                            default:
                                Console.WriteLine("잘못된 입력입니다. 숫자만 입력하세요. ");
                                continue; // 다시 루프 
                        }
                    }
                }
            }
            public void BuyItem(List<Item> items) // 3-1 아이템 구매
            {
                Console.Clear();
                Console.WriteLine("[ 상점아이템 구매 ]\n보유하신 골드로 아이템을 구매할 수 있습니다.\n");
                Console.WriteLine("[ 보유 골드 ]\n");
                Console.WriteLine($"Gold: {Gold} G\n");

                Console.WriteLine("[ 아이템 목록 ]\n");
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {items[i].ItemName} - {items[i].ToolTip} (가격: {items[i].Price} G)");
                }

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int itemNumber) && itemNumber >= 1 && itemNumber <= items.Count)
                    {
                        Item selectedItem = items[itemNumber - 1];
                        if (Gold >= selectedItem.Price && !selectedItem.Purchase)
                        {
                            Gold -= selectedItem.Price;
                            selectedItem.Purchase = true;
                            Console.WriteLine($"{selectedItem.ItemName}을(를) 구매했습니다.");
                        }
                        else if (selectedItem.Purchase)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        }
                        else
                        {
                            Console.WriteLine("Gold 가 부족합니다.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 숫자만 입력하세요. ");
                    }
                }
            }

            public void Dungeon() // 4. 던전
            {
                Console.Clear();
            }

            public void Rest(int selectInput) // 5. 휴식
            {
                if (selectInput >= 1 && selectInput <= 6)
                {
                    // Add logic for saving the game here
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. '1'에서 '6'사이의 숫자를 입력하세요.");
                }
            }

            public void WearItem() // 2-1 인벤토리 아이템 장착
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다. '1'에서 '6'사이의 숫자를 입력하세요.");
            }

            public void Inventory()
            {
                Console.Clear();
                Console.WriteLine("[ 인벤토리 ]\n 보유 중인 아이템을 관리할 수 있습니다.\n");
                Console.WriteLine("[ 아이템 목록 ]\n");

                Console.WriteLine(" 원하시는 행동을 입력해주세요.\n");
                Console.WriteLine(" 0. 나가기\n 1. 장착 관리\n ");

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int inventory)) // 0,1 중에 택1
                    {
                        if (inventory == 0)
                        {
                            getSelect(); // 0 나가기
                            break;
                        }
                        else if (inventory == 1)
                        {
                            WearItem(); // 1 장착 관리
                            break;
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다. 숫자만 입력하세요. ");
                        }
                    }
                }
            }

                public void PlayerInfo() // 플레이어 상태 보기
                {
                    Console.Clear();
                    Console.WriteLine("상태 보기\n");
                    Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
                    Console.WriteLine($"이름:{PlayerName}\n");
                    Console.WriteLine($"Lv.{level:D2}\n"); //level 옆에 D2는 1 표기가 아닌 01 표기를 위함
                    Console.WriteLine($"chad:{Job}\n");
                    Console.WriteLine($"공격력:{Att}\n");
                    Console.WriteLine($"방어력:{Def}\n");
                    Console.WriteLine($"체력:{HP}\n");
                    Console.WriteLine($"Gold: {Gold} G\n");
                    Console.WriteLine("0.나가기\n");
                    Console.WriteLine(" 원하시는 행동을 입력하세요.\n");
                    Console.WriteLine(">>\n");
                
                }
            }
        }
        public void Dungeon() // 4. 던전
        {
            Console.Clear();
        }

        public void Rest() // 5. 휴식
        {
            Console.Clear();
        }

        public static void SaveGame() // 6. 게임 저장
        {
            Console.Clear();
        }
    }
}



   