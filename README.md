# TextRPG

TextRPG 폴더 내의 program.cs 파일에 개인 프로젝트 작업을 하였다.
아직 미숙해서 플레이어 정보의 콘솔창이 제대로 출력되지 않는 버그가 발생한다.

        public String Name { get; } // 아이템 이름
        public String Description { get; } // 아이템 설명
        public int Type { get; } // 아이템 타입 (무기, 방어구 등)
        public int Att { get; } // 공격력
        public int Def { get; } // 방어력
        public int Gold { get; } // 가격
        public bool IsEquipped { get; set; } // 장착 여부
        public static int Itemcount = 0; // 아이템 개수

        // 아이템에 적용한 public 변수 선언이다.

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

        // 아이템 생성자를 통해 아이템 속성값을 변경할 수 있게 하였다.

         // 플레이어 정보 (프로퍼티)
        public string PlayerName { get; set; } //플레이어 이름
        public int Level { get; set; } //플레이어 레벨
        public string Job { get; set; } //플레이어 직업
        public int Att { get; set; } //플레이어 공격력
        public int Def { get; set; } //플레이어 방어력
        public int HP { get; set; } //플레이어 체력
        public int Gold { get; set; } //플레이어 골드

        // 플레이어 정보 값을 받아 변수를 받게 하였다.

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

        // 플레이어의 이름,레벨,직업,공격력,방어력,체력,골드,인벤토리의 default값으로 기본값을 생성하게 하였다.

        public static Store GameStore = new Store(); // 상점 객체 생성

        //플레이어 정보
        static int level = 1;
        static string PlayerName;
        static string Job = "전사";
        static int Att = 10;
        static int Def = 5;
        static int HP = 100;
        static int Gold = 1500;

        // 플레이어 정보의 default값이다.

        // public class로 아이템을 선언하였다.

            public string ItemName { get; set; } //아이템 이름
            public string ToolTip { get; set; } //아이템 설명
            public int Attack { get; set; } // 공격력
            public int Defense { get; set; } // 방어력
            public int Price { get; set; } // 아이템 가격
            public bool Purchase { get; set; } // 구매 여부
            public bool EqippedItem { get; set; } // 장착 여부
            public bool EqipItem { get; set; } // 장착 아이템 여부

       // 아이템의 이름,설명,공격력,방어력,가격,구매 여부,장착 여부, 장착 아이템 여부를 public 값으로 받아내는 함수이다.

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

            // 선언을 통해 이름,설명,공격력,방어력,가격,초기 기본값,장착 여부를 명령해낸다.

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

        // 상점 class를 선언하고 list문을 통해 상점의 아이템 목록을 불러오고 Item.add문을 통해 상점에 아이템을 추가하였다.

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

            // 콘솔 창에 제일 처음으로 나오는 Main 함수이다. 이름을 짓고 TextRPG의 메인 화면으로 들어간다.
            // 메인 화면은 Stage stage문을 통해 stage 함수로 들어간다.

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

        // private 선언을 통해 상점을 초기화하고 new List를 선언해 객체를 생성하여 상점의 아이템을 관리한다.

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

            // stage문 선언을 통하여 선택 루프에 들어온다.

            
