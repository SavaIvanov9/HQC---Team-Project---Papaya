﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Poker.Core;
using Poker.Core.Factories;
using Poker.Enums;
using Poker.Interfaces;
using Poker.Models;
using Poker.Properties;
using Poker.Table;

namespace Poker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void bFold_Click(object sender, EventArgs e)
        {
            Engine.Instance.humanDecision = "fold";
            Engine.Instance.Update();
        }

        private void bCheck_Click(object sender, EventArgs e)
        {
            Engine.Instance.humanDecision = "check";
            Engine.Instance.Update();
        }

        private void bCall_Click(object sender, EventArgs e)
        {
            Engine.Instance.humanDecision = "call";
            Engine.Instance.Update();
        }

        private void bRaise_Click(object sender, EventArgs e)
        {
            Engine.Instance.humanDecision = "raise";
            Engine.Instance.humanRaise = int.Parse(textBoxRaise.Text);
            Engine.Instance.Update();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {

        }

        private void bOptions_Click(object sender, EventArgs e)
        {

        }

        private void bBB_Click(object sender, EventArgs e)
        {

        }

        private void bSB_Click(object sender, EventArgs e)
        {

        }

        //public void InitialDraw()
        //{
        //    Panel playerPanel = new Panel();
        //    int loleh = 500;
        //    playerPanel.Location = new Point(500, 450);
        //    playerPanel.BackColor = Color.DarkBlue;
        //    playerPanel.Size = new Size(100, 175);
        //    playerPanel.Visible = true;
        //    this.Controls.Add(playerPanel);
        //    //Random r = new Random();
        //    //string[] ImgLocation = Directory.GetFiles("Assets\\Cards", "*.png", SearchOption.TopDirectoryOnly);
        //    //Image[] Deck = new Image[52];
        //    //Bitmap img = new Bitmap("Assets\\Back\\");
        //    //PictureBox[] lol = new PictureBox[52];
        //    //Bitmap backImage = new Bitmap("Assets\\Back\\Back.png");
        //    PictureBox lol = new PictureBox();
        //    lol.Location = new System.Drawing.Point(loleh, 200);
        //    lol.Size = new System.Drawing.Size(5, 2);
        //    lol.Dock = DockStyle.Fill;
        //    lol.SizeMode = PictureBoxSizeMode.StretchImage;

            
            

        //    for (int i = 0; i < Engine.Instance.database.CyclePlayers.Count; i++)
        //    {
        //        for (int j = 0; j < Engine.Instance.database.CyclePlayers[i].Hand.Count; j++)
        //        {
                    
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Clubs &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 2)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\5.png") ;
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Clubs &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 3)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\9.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Clubs &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 4)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\13.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Clubs &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 5)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\17.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Clubs &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 6)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\21.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Clubs &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 7)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\25.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Clubs &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 8)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\29.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Clubs &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 9)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\33.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Clubs &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 10)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\37.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Clubs &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 11)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\41.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Clubs &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 12)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\45.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Clubs &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 13)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\49.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Clubs &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 14)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\1.png");
        //                playerPanel.Controls.Add(lol);
        //            }


        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Spades &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 2)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\8.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Spades &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 3)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\12.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Spades &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 4)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\16.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Spades &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 5)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\20.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Spades &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 6)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\24.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Spades &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 7)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\28.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Spades &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 8)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\32.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Spades &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 9)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\36.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Spades &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 10)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\40.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Spades &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 11)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\44.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Spades &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 12)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\48.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Spades &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 13)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\52.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Spades &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 14)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\4.png");
        //                playerPanel.Controls.Add(lol);
        //            }


        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Hearts &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 2)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\7.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Hearts &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 3)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\11.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Hearts &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 4)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\15.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Hearts &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 5)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\19.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Hearts &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 6)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\23.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Hearts &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 7)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\27.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Hearts &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 8)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\31.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Hearts &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 9)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\35.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Hearts &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 10)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\39.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Hearts &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 11)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\43.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Hearts &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 12)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\47.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Hearts &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 13)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\51.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Hearts &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 14)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\3.png");
        //                playerPanel.Controls.Add(lol);
        //            }


        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Diamonds &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 2)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\6.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Diamonds &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 3)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\10.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Diamonds &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 4)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\14.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Diamonds &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 5)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\18.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Diamonds &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 6)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\22.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Diamonds &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 7)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\26.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Diamonds &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 8)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\30.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Diamonds &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 9)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\34.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Diamonds &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 10)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\38.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Diamonds &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 11)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\42.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Diamonds &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 12)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\46.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Diamonds &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 13)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\50.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            if (Engine.Instance.database.CyclePlayers[i].Hand[j].CardType == CardType.Diamonds &&
        //                Engine.Instance.database.CyclePlayers[i].Hand[j].CardPower == 14)
        //            {
        //                lol.Image = new Bitmap("Assets\\Cards\\2.png");
        //                playerPanel.Controls.Add(lol);
        //            }
        //            loleh += 100;
        //        }
        //    }
            

        //}

    }




    //private void Layout_Change(object sender, LayoutEventArgs e)
    //{
    //    width = this.width;
    //    height = this.height;
    //}

    //public partial class Form1 : Form
    //{
    //    #region Variables

    //    //private readonly IBotFactory botFactory = new BotFactory();
    //    //private readonly IHumanFactory humanFactory = new HumanFactory();
    //    //private readonly ICardFactory cardFactory = new CardFactory();
    //    //private readonly IPokerDatabase database = new PokerDatabase();

    //    ProgressBar turnTime = new ProgressBar();
    //    public int Nm; //TODO: refactor
    //    Panel playerPanel = new Panel();
    //    Panel bot1Panel = new Panel();
    //    Panel bot2Panel = new Panel();
    //    Panel bot3Panel = new Panel();
    //    Panel bot4Panel = new Panel();
    //    Panel bot5Panel = new Panel();

    //    private int call = 500;
    //    int foldedPlayers = 5;
    //    public int Chips = 10000;
    //    private int bot1Chips = 10000;
    //    private int bot2Chips = 10000;
    //    private int bot3Chips = 10000;
    //    private int bot4Chips = 10000;
    //    private int bot5Chips = 10000;

    //    private double type;
    //    private int rounds = 0;

    //    private double b1Power;
    //    private double b2Power;
    //    private double b3Power;
    //    private double b4Power;
    //    private double b5Power;
    //    private double pPower = 0;

    //    private double pType = -1;
    //    private double Raise = 0;
    //    private double b1Type = -1;
    //    private double b2Type = -1;
    //    private double b3Type = -1;
    //    private double b4Type = -1;
    //    private double b5Type = -1;

    //    private bool B1turn = false;
    //    private bool B2turn = false;
    //    private bool B3turn = false;
    //    private bool B4turn = false;
    //    private bool B5turn = false;

    //    private bool B1Fturn = false;
    //    private bool B2Fturn = false;
    //    private bool B3Fturn = false;
    //    private bool B4Fturn = false;
    //    private bool B5Fturn = false;

    //    private bool pFolded;
    //    private bool b1Folded;
    //    private bool b2Folded;
    //    private bool b3Folded;
    //    private bool b4Folded;
    //    private bool b5Folded;

    //    private bool intsadded;
    //    private bool changed;

    //    private int pCall = 0;
    //    private int b1Call = 0;
    //    private int b2Call = 0;
    //    private int b3Call = 0;
    //    private int b4Call = 0;
    //    private int b5Call = 0;

    //    private int pRaise = 0;
    //    private int b1Raise = 0;
    //    private int b2Raise = 0;
    //    private int b3Raise = 0;
    //    private int b4Raise = 0;
    //    private int b5Raise = 0;

    //    private int height;
    //    private int width;

    //    private int winners = 0;

    //    private int Flop = 1;
    //    private int Turn = 2;
    //    private int River = 3;
    //    private int End = 4;

    //    private int maxLeft = 6;
    //    private int last = 123;
    //    private int raisedTurn = 1;

    //    List<bool?> bools = new List<bool?>();
    //    List<Type> Win = new List<Type>();
    //    List<string> CheckWinners = new List<string>();
    //    List<int> ints = new List<int>();

    //    private bool PFturn = false;
    //    private bool Pturn = true;
    //    private bool restart = false;
    //    private bool raising = false;

    //    Type sorted;

    //    string[] ImgLocation = Directory.GetFiles("Assets\\Cards", "*.png", SearchOption.TopDirectoryOnly);

    //    /*string[] ImgLocation ={
    //               "Assets\\Cards\\33.png","Assets\\Cards\\22.png",
    //                "Assets\\Cards\\29.png","Assets\\Cards\\21.png",
    //                "Assets\\Cards\\36.png","Assets\\Cards\\17.png",
    //                "Assets\\Cards\\40.png","Assets\\Cards\\16.png",
    //                "Assets\\Cards\\5.png","Assets\\Cards\\47.png",
    //                "Assets\\Cards\\37.png","Assets\\Cards\\13.png",

    //                "Assets\\Cards\\12.png",
    //                "Assets\\Cards\\8.png","Assets\\Cards\\18.png",
    //                "Assets\\Cards\\15.png","Assets\\Cards\\27.png"};*/

    //    int[] Reserve = new int[17];
    //    Image[] Deck = new Image[52];
    //    PictureBox[] lol = new PictureBox[52];

    //    Timer timer = new Timer();
    //    Timer Updates = new Timer();
    //    private int timeRemaining = 60;
    //    private int i;
    //    private int bigBlind = 500;
    //    private int smallBlind = 250;
    //    private int up = 10000000;
    //    private int turnCount = 0;
    //    #endregion

    //    public Form1()
    //    {
    //        //pokerDatabase.AddBot("Bot1", cards, 2, 2);
    //        // bots.Add(botFactory.CreateBot("Steven", cards, 2));
    //        // DialogResult lole;
    //        //lole = MessageBox.Show(bots[0].Name);

    //        //database.BotPlayers.Add(this.botFactory.CreateBot("go6o", 10));
    //        //DialogResult huie = MessageBox.Show(database.BotPlayers[0].Name);
    //        //DialogResult hui = MessageBox.Show(database.HumanPlayers[0].Name);


    //        //bools.Add(PFturn); bools.Add(B1Fturn); bools.Add(B2Fturn); bools.Add(B3Fturn); bools.Add(B4Fturn); bools.Add(B5Fturn);
    //        call = bigBlind;
    //        MaximizeBox = false;
    //        MinimizeBox = false;

    //        Updates.Start();
    //        InitializeComponent();

    //        width = this.Width;
    //        height = this.Height;

    //        Shuffle();

    //        tbPot.Enabled = false;
    //        tbChips.Enabled = false;
    //        tbBotChips1.Enabled = false;
    //        tbBotChips2.Enabled = false;
    //        tbBotChips3.Enabled = false;
    //        tbBotChips4.Enabled = false;
    //        tbBotChips5.Enabled = false;

    //        tbChips.Text = "Chips : " + Chips.ToString();
    //        tbBotChips1.Text = "Chips : " + bot1Chips.ToString();
    //        tbBotChips2.Text = "Chips : " + bot2Chips.ToString();
    //        tbBotChips3.Text = "Chips : " + bot3Chips.ToString();
    //        tbBotChips4.Text = "Chips : " + bot4Chips.ToString();
    //        tbBotChips5.Text = "Chips : " + bot5Chips.ToString();
    //        timer.Interval = (1 * 1 * 1000);
    //        timer.Tick += timer_Tick;
    //        Updates.Interval = (1 * 1 * 100);
    //        Updates.Tick += Update_Tick;

    //        // Fixed names of controls
    //        textBoxBigBlind.Visible = true;
    //        textBoxSmallBlind.Visible = true;
    //        buttonBigBlind.Visible = true;
    //        buttonSmallBlind.Visible = true;
    //        textBoxBigBlind.Visible = true;
    //        textBoxSmallBlind.Visible = true;
    //        buttonBigBlind.Visible = true;
    //        buttonSmallBlind.Visible = true;
    //        textBoxBigBlind.Visible = false;
    //        textBoxSmallBlind.Visible = false;
    //        buttonBigBlind.Visible = false;
    //        buttonSmallBlind.Visible = false;
    //        textBoxRaise.Text = (bigBlind * 2).ToString();
    //    }

    //    //shuffling the cards
    //    async Task Shuffle()
    //    {
    //        bools.Add(PFturn);
    //        bools.Add(B1Fturn);
    //        bools.Add(B2Fturn);
    //        bools.Add(B3Fturn);
    //        bools.Add(B4Fturn);
    //        bools.Add(B5Fturn);

    //        bCall.Enabled = false;
    //        bRaise.Enabled = false;
    //        bFold.Enabled = false;
    //        bCheck.Enabled = false;
    //        MaximizeBox = false;
    //        MinimizeBox = false;
    //        bool check = false;
    //        Bitmap backImage = new Bitmap("Assets\\Back\\Back.png");
    //        int horizontal = 580, vertical = 480;
    //        Random r = new Random();

    //        for (i = ImgLocation.Length; i > 0; i--)
    //        {
    //            int j = r.Next(i);
    //            var k = ImgLocation[j];
    //            ImgLocation[j] = ImgLocation[i - 1];
    //            ImgLocation[i - 1] = k;
    //        }

    //        for (i = 0; i < 17; i++)
    //        {
    //            Deck[i] = Image.FromFile(ImgLocation[i]);

    //            var charsToRemove = new string[] { "Assets\\Cards\\", ".png" };

    //            foreach (var c in charsToRemove)
    //            {
    //                ImgLocation[i] = ImgLocation[i].Replace(c, string.Empty);
    //            }

    //            Reserve[i] = int.Parse(ImgLocation[i]) - 1;
    //            lol = new PictureBox();
    //            lol.SizeMode = PictureBoxSizeMode.StretchImage;
    //            lol.Height = 130;
    //            lol.Width = 80;
    //            this.Controls.Add(lol);
    //            lol.Name = "pb" + i.ToString();
    //            await Task.Delay(200);

    //            #region Throwing Cards
    //            if (i < 2)
    //            {
    //                if (lol[0].Tag != null)
    //                {
    //                    lol[1].Tag = Reserve[1];
    //                }
    //                lol[0].Tag = Reserve[0];
    //                lol.Image = Deck[i];
    //                lol.Anchor = (AnchorStyles.Bottom);
    //                //lol.Dock = DockStyle.Top;
    //                lol.Location = new Point(horizontal, vertical);
    //                horizontal += lol.Width;
    //                this.Controls.Add(playerPanel);
    //                playerPanel.Location = new Point(lol[0].Left - 10, lol[0].Top - 10);
    //                playerPanel.BackColor = Color.DarkBlue;
    //                playerPanel.Height = 150;
    //                playerPanel.Width = 180;
    //                playerPanel.Visible = false;
    //            }

    //            if (bot1Chips > 0)
    //            {
    //                foldedPlayers--;
    //                if (i >= 2 && i < 4)
    //                {
    //                    if (lol[2].Tag != null)
    //                    {
    //                        lol[3].Tag = Reserve[3];
    //                    }
    //                    lol[2].Tag = Reserve[2];
    //                    if (!check)
    //                    {
    //                        horizontal = 15;
    //                        vertical = 420;
    //                    }
    //                    check = true;
    //                    lol.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
    //                    lol.Image = backImage;
    //                    //lol.Image = Deck[i];
    //                    lol.Location = new Point(horizontal, vertical);
    //                    horizontal += lol.Width;
    //                    lol.Visible = true;
    //                    this.Controls.Add(bot1Panel);
    //                    bot1Panel.Location = new Point(lol[2].Left - 10, lol[2].Top - 10);
    //                    bot1Panel.BackColor = Color.DarkBlue;
    //                    bot1Panel.Height = 150;
    //                    bot1Panel.Width = 180;
    //                    bot1Panel.Visible = false;
    //                    if (i == 3)
    //                    {
    //                        check = false;
    //                    }
    //                }
    //            }

    //            if (bot2Chips > 0)
    //            {
    //                foldedPlayers--;
    //                if (i >= 4 && i < 6)
    //                {
    //                    if (lol[4].Tag != null)
    //                    {
    //                        lol[5].Tag = Reserve[5];
    //                    }
    //                    lol[4].Tag = Reserve[4];
    //                    if (!check)
    //                    {
    //                        horizontal = 75;
    //                        vertical = 65;
    //                    }
    //                    check = true;
    //                    lol.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
    //                    lol.Image = backImage;
    //                    //lol.Image = Deck[i];
    //                    lol.Location = new Point(horizontal, vertical);
    //                    horizontal += lol.Width;
    //                    lol.Visible = true;
    //                    this.Controls.Add(bot2Panel);
    //                    bot2Panel.Location = new Point(lol[4].Left - 10, lol[4].Top - 10);
    //                    bot2Panel.BackColor = Color.DarkBlue;
    //                    bot2Panel.Height = 150;
    //                    bot2Panel.Width = 180;
    //                    bot2Panel.Visible = false;
    //                    if (i == 5)
    //                    {
    //                        check = false;
    //                    }
    //                }
    //            }
    //            if (bot3Chips > 0)
    //            {
    //                foldedPlayers--;
    //                if (i >= 6 && i < 8)
    //                {
    //                    if (lol[6].Tag != null)
    //                    {
    //                        lol[7].Tag = Reserve[7];
    //                    }
    //                    lol[6].Tag = Reserve[6];
    //                    if (!check)
    //                    {
    //                        horizontal = 590;
    //                        vertical = 25;
    //                    }
    //                    check = true;
    //                    lol.Anchor = (AnchorStyles.Top);
    //                    lol.Image = backImage;
    //                    //lol.Image = Deck[i];
    //                    lol.Location = new Point(horizontal, vertical);
    //                    horizontal += lol.Width;
    //                    lol.Visible = true;
    //                    this.Controls.Add(bot3Panel);
    //                    bot3Panel.Location = new Point(lol[6].Left - 10, lol[6].Top - 10);
    //                    bot3Panel.BackColor = Color.DarkBlue;
    //                    bot3Panel.Height = 150;
    //                    bot3Panel.Width = 180;
    //                    bot3Panel.Visible = false;
    //                    if (i == 7)
    //                    {
    //                        check = false;
    //                    }
    //                }
    //            }
    //            if (bot4Chips > 0)
    //            {
    //                foldedPlayers--;
    //                if (i >= 8 && i < 10)
    //                {
    //                    if (lol[8].Tag != null)
    //                    {
    //                        lol[9].Tag = Reserve[9];
    //                    }
    //                    lol[8].Tag = Reserve[8];
    //                    if (!check)
    //                    {
    //                        horizontal = 1115;
    //                        vertical = 65;
    //                    }
    //                    check = true;
    //                    lol.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
    //                    lol.Image = backImage;
    //                    //lol.Image = Deck[i];
    //                    lol.Location = new Point(horizontal, vertical);
    //                    horizontal += lol.Width;
    //                    lol.Visible = true;
    //                    this.Controls.Add(bot4Panel);
    //                    bot4Panel.Location = new Point(lol[8].Left - 10, lol[8].Top - 10);
    //                    bot4Panel.BackColor = Color.DarkBlue;
    //                    bot4Panel.Height = 150;
    //                    bot4Panel.Width = 180;
    //                    bot4Panel.Visible = false;
    //                    if (i == 9)
    //                    {
    //                        check = false;
    //                    }
    //                }
    //            }
    //            if (bot5Chips > 0)
    //            {
    //                foldedPlayers--;
    //                if (i >= 10 && i < 12)
    //                {
    //                    if (lol[10].Tag != null)
    //                    {
    //                        lol[11].Tag = Reserve[11];
    //                    }
    //                    lol[10].Tag = Reserve[10];
    //                    if (!check)
    //                    {
    //                        horizontal = 1160;
    //                        vertical = 420;
    //                    }
    //                    check = true;
    //                    lol.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
    //                    lol.Image = backImage;
    //                    //lol.Image = Deck[i];
    //                    lol.Location = new Point(horizontal, vertical);
    //                    horizontal += lol.Width;
    //                    lol.Visible = true;
    //                    this.Controls.Add(bot5Panel);
    //                    bot5Panel.Location = new Point(lol[10].Left - 10, lol[10].Top - 10);
    //                    bot5Panel.BackColor = Color.DarkBlue;
    //                    bot5Panel.Height = 150;
    //                    bot5Panel.Width = 180;
    //                    bot5Panel.Visible = false;
    //                    if (i == 11)
    //                    {
    //                        check = false;
    //                    }
    //                }
    //            }
    //            if (i >= 12)
    //            {
    //                lol[12].Tag = Reserve[12];
    //                if (i > 12) lol[13].Tag = Reserve[13];
    //                if (i > 13) lol[14].Tag = Reserve[14];
    //                if (i > 14) lol[15].Tag = Reserve[15];
    //                if (i > 15)
    //                {
    //                    lol[16].Tag = Reserve[16];

    //                }
    //                if (!check)
    //                {
    //                    horizontal = 410;
    //                    vertical = 265;
    //                }
    //                check = true;
    //                if (lol != null)
    //                {
    //                    lol.Anchor = AnchorStyles.None;
    //                    lol.Image = backImage;
    //                    //lol.Image = Deck[i];
    //                    lol.Location = new Point(horizontal, vertical);
    //                    horizontal += 110;
    //                }
    //            }
    //            #endregion

    //            if (bot1Chips <= 0)
    //            {
    //                B1Fturn = true;
    //                lol[2].Visible = false;
    //                lol[3].Visible = false;
    //            }
    //            else
    //            {
    //                B1Fturn = false;
    //                if (i == 3)
    //                {
    //                    if (lol[3] != null)
    //                    {
    //                        lol[2].Visible = true;
    //                        lol[3].Visible = true;
    //                    }
    //                }
    //            }
    //            if (bot2Chips <= 0)
    //            {
    //                B2Fturn = true;
    //                lol[4].Visible = false;
    //                lol[5].Visible = false;
    //            }
    //            else
    //            {
    //                B2Fturn = false;
    //                if (i == 5)
    //                {
    //                    if (lol[5] != null)
    //                    {
    //                        lol[4].Visible = true;
    //                        lol[5].Visible = true;
    //                    }
    //                }
    //            }
    //            if (bot3Chips <= 0)
    //            {
    //                B3Fturn = true;
    //                lol[6].Visible = false;
    //                lol[7].Visible = false;
    //            }
    //            else
    //            {
    //                B3Fturn = false;
    //                if (i == 7)
    //                {
    //                    if (lol[7] != null)
    //                    {
    //                        lol[6].Visible = true;
    //                        lol[7].Visible = true;
    //                    }
    //                }
    //            }
    //            if (bot4Chips <= 0)
    //            {
    //                B4Fturn = true;
    //                lol[8].Visible = false;
    //                lol[9].Visible = false;
    //            }
    //            else
    //            {
    //                B4Fturn = false;
    //                if (i == 9)
    //                {
    //                    if (lol[9] != null)
    //                    {
    //                        lol[8].Visible = true;
    //                        lol[9].Visible = true;
    //                    }
    //                }
    //            }
    //            if (bot5Chips <= 0)
    //            {
    //                B5Fturn = true;
    //                lol[10].Visible = false;
    //                lol[11].Visible = false;
    //            }
    //            else
    //            {
    //                B5Fturn = false;
    //                if (i == 11)
    //                {
    //                    if (lol[11] != null)
    //                    {
    //                        lol[10].Visible = true;
    //                        lol[11].Visible = true;
    //                    }
    //                }
    //            }
    //            if (i == 16)
    //            {
    //                if (!restart)
    //                {
    //                    MaximizeBox = true;
    //                    MinimizeBox = true;
    //                }
    //                timer.Start();
    //            }
    //        }
    //        if (foldedPlayers == 5)
    //        {
    //            DialogResult dialogResult = MessageBox.Show("Would You Like To Play Again ?", "You Won , Congratulations ! ", MessageBoxButtons.YesNo);
    //            if (dialogResult == DialogResult.Yes)
    //            {
    //                Application.Restart();
    //            }
    //            else if (dialogResult == DialogResult.No)
    //            {
    //                Application.Exit();
    //            }
    //        }
    //        else
    //        {
    //            foldedPlayers = 5;
    //        }
    //        if (i == 17)
    //        {
    //            bRaise.Enabled = true;
    //            bCall.Enabled = true;
    //            bRaise.Enabled = true;
    //            bRaise.Enabled = true;
    //            bFold.Enabled = true;
    //        }
    //    }
    //    async Task Turns()
    //    {
    //        #region Rotating
    //        if (!PFturn)
    //        {
    //            if (Pturn)
    //            {
    //                FixCall(pStatus, ref pCall, ref pRaise, 1);
    //                //MessageBox.Show("Player's Turn");
    //                pbTimer.Visible = true;
    //                pbTimer.Value = 1000;
    //                timeRemaining = 60;
    //                up = 10000000;
    //                timer.Start();
    //                bRaise.Enabled = true;
    //                bCall.Enabled = true;
    //                bRaise.Enabled = true;
    //                bRaise.Enabled = true;
    //                bFold.Enabled = true;
    //                turnCount++;
    //                FixCall(pStatus, ref pCall, ref pRaise, 2);
    //            }
    //        }
    //        if (PFturn || !Pturn)
    //        {
    //            await AllIn();
    //            if (PFturn && !pFolded)
    //            {

    //                if (bCall.Text.Contains("All in") == false || bRaise.Text.Contains("All in") == false)
    //                {
    //                    bools.RemoveAt(0);
    //                    bools.Insert(0, null);
    //                    maxLeft--;
    //                    pFolded = true;
    //                }
    //            }
    //            await CheckRaise(0, 0);
    //            pbTimer.Visible = false;
    //            bRaise.Enabled = false;
    //            bCall.Enabled = false;
    //            bRaise.Enabled = false;
    //            bRaise.Enabled = false;
    //            bFold.Enabled = false;
    //            timer.Stop();
    //            B1turn = true;
    //            if (!B1Fturn)
    //            {
    //                if (B1turn)
    //                {
    //                    FixCall(b1Status, ref b1Call, ref b1Raise, 1);
    //                    FixCall(b1Status, ref b1Call, ref b1Raise, 2);
    //                    Rules(2, 3, "Bot 1", ref b1Type, ref b1Power, B1Fturn);
    //                    MessageBox.Show("Bot 1's Turn");
    //                    AI(2, 3, ref bot1Chips, ref B1turn, ref B1Fturn, b1Status, 0, b1Power, b1Type);
    //                    turnCount++;
    //                    last = 1;
    //                    B1turn = false;
    //                    B2turn = true;
    //                }
    //            }
    //            if (B1Fturn && !b1Folded)
    //            {
    //                bools.RemoveAt(1);
    //                bools.Insert(1, null);
    //                maxLeft--;
    //                b1Folded = true;
    //            }
    //            if (B1Fturn || !B1turn)
    //            {
    //                await CheckRaise(1, 1);
    //                B2turn = true;
    //            }
    //            if (!B2Fturn)
    //            {
    //                if (B2turn)
    //                {
    //                    FixCall(b2Status, ref b2Call, ref b2Raise, 1);
    //                    FixCall(b2Status, ref b2Call, ref b2Raise, 2);
    //                    Rules(4, 5, "Bot 2", ref b2Type, ref b2Power, B2Fturn);
    //                    MessageBox.Show("Bot 2's Turn");
    //                    AI(4, 5, ref bot2Chips, ref B2turn, ref B2Fturn, b2Status, 1, b2Power, b2Type);
    //                    turnCount++;
    //                    last = 2;
    //                    B2turn = false;
    //                    B3turn = true;
    //                }
    //            }
    //            if (B2Fturn && !b2Folded)
    //            {
    //                bools.RemoveAt(2);
    //                bools.Insert(2, null);
    //                maxLeft--;
    //                b2Folded = true;
    //            }
    //            if (B2Fturn || !B2turn)
    //            {
    //                await CheckRaise(2, 2);
    //                B3turn = true;
    //            }
    //            if (!B3Fturn)
    //            {
    //                if (B3turn)
    //                {
    //                    FixCall(b3Status, ref b3Call, ref b3Raise, 1);
    //                    FixCall(b3Status, ref b3Call, ref b3Raise, 2);
    //                    Rules(6, 7, "Bot 3", ref b3Type, ref b3Power, B3Fturn);
    //                    MessageBox.Show("Bot 3's Turn");
    //                    AI(6, 7, ref bot3Chips, ref B3turn, ref B3Fturn, b3Status, 2, b3Power, b3Type);
    //                    turnCount++;
    //                    last = 3;
    //                    B3turn = false;
    //                    B4turn = true;
    //                }
    //            }
    //            if (B3Fturn && !b3Folded)
    //            {
    //                bools.RemoveAt(3);
    //                bools.Insert(3, null);
    //                maxLeft--;
    //                b3Folded = true;
    //            }
    //            if (B3Fturn || !B3turn)
    //            {
    //                await CheckRaise(3, 3);
    //                B4turn = true;
    //            }
    //            if (!B4Fturn)
    //            {
    //                if (B4turn)
    //                {
    //                    FixCall(b4Status, ref b4Call, ref b4Raise, 1);
    //                    FixCall(b4Status, ref b4Call, ref b4Raise, 2);
    //                    Rules(8, 9, "Bot 4", ref b4Type, ref b4Power, B4Fturn);
    //                    MessageBox.Show("Bot 4's Turn");
    //                    AI(8, 9, ref bot4Chips, ref B4turn, ref B4Fturn, b4Status, 3, b4Power, b4Type);
    //                    turnCount++;
    //                    last = 4;
    //                    B4turn = false;
    //                    B5turn = true;
    //                }
    //            }
    //            if (B4Fturn && !b4Folded)
    //            {
    //                bools.RemoveAt(4);
    //                bools.Insert(4, null);
    //                maxLeft--;
    //                b4Folded = true;
    //            }
    //            if (B4Fturn || !B4turn)
    //            {
    //                await CheckRaise(4, 4);
    //                B5turn = true;
    //            }
    //            if (!B5Fturn)
    //            {
    //                if (B5turn)
    //                {
    //                    FixCall(b5Status, ref b5Call, ref b5Raise, 1);
    //                    FixCall(b5Status, ref b5Call, ref b5Raise, 2);
    //                    Rules(10, 11, "Bot 5", ref b5Type, ref b5Power, B5Fturn);
    //                    MessageBox.Show("Bot 5's Turn");
    //                    AI(10, 11, ref bot5Chips, ref B5turn, ref B5Fturn, b5Status, 4, b5Power, b5Type);
    //                    turnCount++;
    //                    last = 5;
    //                    B5turn = false;
    //                }
    //            }
    //            if (B5Fturn && !b5Folded)
    //            {
    //                bools.RemoveAt(5);
    //                bools.Insert(5, null);
    //                maxLeft--;
    //                b5Folded = true;
    //            }
    //            if (B5Fturn || !B5turn)
    //            {
    //                await CheckRaise(5, 5);
    //                Pturn = true;
    //            }
    //            if (PFturn && !pFolded)
    //            {
    //                if (bCall.Text.Contains("All in") == false || bRaise.Text.Contains("All in") == false)
    //                {
    //                    bools.RemoveAt(0);
    //                    bools.Insert(0, null);
    //                    maxLeft--;
    //                    pFolded = true;
    //                }
    //            }
    //            #endregion
    //            await AllIn();
    //            if (!restart)
    //            {
    //                await Turns();
    //            }
    //            restart = false;
    //        }
    //    }

    //    void Rules(int cardOne, int cardTwo, string currentText, ref double curentCardsValue, ref double power, bool foldedTurn)
    //    {
    //        //if (cardOne == 0 && cardTwo == 1)
    //        //{
    //        //}

    //        if (!foldedTurn || cardOne == 0 && cardTwo == 1 && pStatus.Text.Contains("Fold") == false)
    //        {
    //            #region Variables

    //            bool done = false;
    //            bool vf = false;

    //            int[] smallStraight = new int[5];
    //            int[] bigStraight = new int[7];

    //            bigStraight[0] = Reserve[cardOne];
    //            bigStraight[1] = Reserve[cardTwo];
    //            smallStraight[0] = bigStraight[2] = Reserve[12];
    //            smallStraight[1] = bigStraight[3] = Reserve[13];
    //            smallStraight[2] = bigStraight[4] = Reserve[14];
    //            smallStraight[3] = bigStraight[5] = Reserve[15];
    //            smallStraight[4] = bigStraight[6] = Reserve[16];

    //            var straightOfClubs = bigStraight.Where(o => o % 4 == 0).ToArray();
    //            var straightOfDiamonds = bigStraight.Where(o => o % 4 == 1).ToArray();
    //            var straightOfHearts = bigStraight.Where(o => o % 4 == 2).ToArray();
    //            var straightOfSpades = bigStraight.Where(o => o % 4 == 3).ToArray();

    //            var straightOfClubsValue = straightOfClubs.Select(o => o / 4).Distinct().ToArray();
    //            var straightOfDiamondsValue = straightOfDiamonds.Select(o => o / 4).Distinct().ToArray();
    //            var straightOfHeartsValue = straightOfHearts.Select(o => o / 4).Distinct().ToArray();
    //            var straightOfSpadesValue = straightOfSpades.Select(o => o / 4).Distinct().ToArray();

    //            Array.Sort(bigStraight);
    //            Array.Sort(straightOfClubsValue);
    //            Array.Sort(straightOfDiamondsValue);
    //            Array.Sort(straightOfHeartsValue);
    //            Array.Sort(straightOfSpadesValue);

    //            const int CardsOnTable = 16;

    //            #endregion
    //            for (i = 0; i < CardsOnTable; i++)
    //            {
    //                if (Reserve[i] == int.Parse(lol[cardOne].Tag.ToString())
    //                    && Reserve[i + 1] == int.Parse(lol[cardTwo].Tag.ToString()))
    //                {
    //                    //Pair from Hand curentCardsValue = 1
    //                    CheckForPairFromHand(ref curentCardsValue, ref power);

    //                    //Pair or Two Pairs from Table curentCardsValue = 2 || 0
    //                    CheckForPairTwoPair(ref curentCardsValue, ref power);

    //                    //Two Pairs curentCardsValue = 2
    //                    CheckForTwoPair(ref curentCardsValue, ref power);

    //                    //Three of a kind curentCardsValue = 3
    //                    CheckForThreeOfAKind(ref curentCardsValue, ref power, bigStraight);

    //                    //Straight curentCardsValue = 4
    //                    CheckForStraight(ref curentCardsValue, ref power, bigStraight);

    //                    //Flush curentCardsValue = 5 || 5.5
    //                    CheckForFlush(ref curentCardsValue, ref power, ref vf, smallStraight);

    //                    //Full House curentCardsValue = 6
    //                    CheckForFullHouse(ref curentCardsValue, ref power, ref done, bigStraight);

    //                    //Four of a Kind curentCardsValue = 7
    //                    CheckForFourOfAKind(ref curentCardsValue, ref power, bigStraight);

    //                    //Straight Flush curentCardsValue = 8 || 9
    //                    CheckForBigStraightFlush(ref curentCardsValue, ref power, straightOfClubsValue, straightOfDiamondsValue, straightOfHeartsValue, straightOfSpadesValue);

    //                    //High Card curentCardsValue = -1
    //                    CheckForHighCard(ref curentCardsValue, ref power);
    //                }
    //            }
    //        }
    //    }

    //    private void CheckForBigStraightFlush(ref double current, ref double Power, int[] st1, int[] st2, int[] st3, int[] st4)
    //    {
    //        if (current >= -1)
    //        {
    //            if (st1.Length >= 5)
    //            {
    //                if (st1[0] + 4 == st1[4])
    //                {
    //                    current = 8;
    //                    Power = (st1.Max()) / 4 + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 8 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                }
    //                if (st1[0] == 0 && st1[1] == 9 && st1[2] == 10 && st1[3] == 11 && st1[0] + 12 == st1[4])
    //                {
    //                    current = 9;
    //                    Power = (st1.Max()) / 4 + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 9 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                }
    //            }
    //            if (st2.Length >= 5)
    //            {
    //                if (st2[0] + 4 == st2[4])
    //                {
    //                    current = 8;
    //                    Power = (st2.Max()) / 4 + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 8 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                }
    //                if (st2[0] == 0 && st2[1] == 9 && st2[2] == 10 && st2[3] == 11 && st2[0] + 12 == st2[4])
    //                {
    //                    current = 9;
    //                    Power = (st2.Max()) / 4 + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 9 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                }
    //            }
    //            if (st3.Length >= 5)
    //            {
    //                if (st3[0] + 4 == st3[4])
    //                {
    //                    current = 8;
    //                    Power = (st3.Max()) / 4 + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 8 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                }
    //                if (st3[0] == 0 && st3[1] == 9 && st3[2] == 10 && st3[3] == 11 && st3[0] + 12 == st3[4])
    //                {
    //                    current = 9;
    //                    Power = (st3.Max()) / 4 + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 9 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                }
    //            }
    //            if (st4.Length >= 5)
    //            {
    //                if (st4[0] + 4 == st4[4])
    //                {
    //                    current = 8;
    //                    Power = (st4.Max()) / 4 + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 8 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                }
    //                if (st4[0] == 0 && st4[1] == 9 && st4[2] == 10 && st4[3] == 11 && st4[0] + 12 == st4[4])
    //                {
    //                    current = 9;
    //                    Power = (st4.Max()) / 4 + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 9 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                }
    //            }
    //        }
    //    }
    //    private void CheckForFourOfAKind(ref double current, ref double Power, int[] bigStraight)
    //    {
    //        if (current >= -1)
    //        {
    //            for (int j = 0; j <= 3; j++)
    //            {
    //                if (bigStraight[j] / 4 == bigStraight[j + 1] / 4 && bigStraight[j] / 4 == bigStraight[j + 2] / 4 &&
    //                    bigStraight[j] / 4 == bigStraight[j + 3] / 4)
    //                {
    //                    current = 7;
    //                    Power = (bigStraight[j] / 4) * 4 + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 7 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                }
    //                if (bigStraight[j] / 4 == 0 && bigStraight[j + 1] / 4 == 0 && bigStraight[j + 2] / 4 == 0 && bigStraight[j + 3] / 4 == 0)
    //                {
    //                    current = 7;
    //                    Power = 13 * 4 + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 7 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                }
    //            }
    //        }
    //    }
    //    private void CheckForFullHouse(ref double current, ref double Power, ref bool done, int[] bigStraight)
    //    {
    //        if (current >= -1)
    //        {
    //            type = Power;
    //            for (int j = 0; j <= 12; j++)
    //            {
    //                var fh = bigStraight.Where(o => o / 4 == j).ToArray();
    //                if (fh.Length == 3 || done)
    //                {
    //                    if (fh.Length == 2)
    //                    {
    //                        if (fh.Max() / 4 == 0)
    //                        {
    //                            current = 6;
    //                            Power = 13 * 2 + current * 100;
    //                            Win.Add(new Type() { Power = Power, Current = 6 });
    //                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                            break;
    //                        }
    //                        if (fh.Max() / 4 > 0)
    //                        {
    //                            current = 6;
    //                            Power = fh.Max() / 4 * 2 + current * 100;
    //                            Win.Add(new Type() { Power = Power, Current = 6 });
    //                            sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                            break;
    //                        }
    //                    }
    //                    if (!done)
    //                    {
    //                        if (fh.Max() / 4 == 0)
    //                        {
    //                            Power = 13;
    //                            done = true;
    //                            j = -1;
    //                        }
    //                        else
    //                        {
    //                            Power = fh.Max() / 4;
    //                            done = true;
    //                            j = -1;
    //                        }
    //                    }
    //                }
    //            }
    //            if (current != 6)
    //            {
    //                Power = type;
    //            }
    //        }
    //    }
    //    private void CheckForFlush(ref double current, ref double Power, ref bool vf, int[] bigsmallStraight)
    //    {
    //        if (current >= -1)
    //        {
    //            var f1 = bigsmallStraight.Where(o => o % 4 == 0).ToArray();
    //            var f2 = bigsmallStraight.Where(o => o % 4 == 1).ToArray();
    //            var f3 = bigsmallStraight.Where(o => o % 4 == 2).ToArray();
    //            var f4 = bigsmallStraight.Where(o => o % 4 == 3).ToArray();
    //            if (f1.Length == 3 || f1.Length == 4)
    //            {
    //                if (Reserve[i] % 4 == Reserve[i + 1] % 4 && Reserve[i] % 4 == f1[0] % 4)
    //                {
    //                    if (Reserve[i] / 4 > f1.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = Reserve[i] + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                    if (Reserve[i + 1] / 4 > f1.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = Reserve[i + 1] + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                    else if (Reserve[i] / 4 < f1.Max() / 4 && Reserve[i + 1] / 4 < f1.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = f1.Max() + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                }
    //            }
    //            if (f1.Length == 4)//different cards in hand
    //            {
    //                if (Reserve[i] % 4 != Reserve[i + 1] % 4 && Reserve[i] % 4 == f1[0] % 4)
    //                {
    //                    if (Reserve[i] / 4 > f1.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = Reserve[i] + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                    else
    //                    {
    //                        current = 5;
    //                        Power = f1.Max() + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                }
    //                if (Reserve[i + 1] % 4 != Reserve[i] % 4 && Reserve[i + 1] % 4 == f1[0] % 4)
    //                {
    //                    if (Reserve[i + 1] / 4 > f1.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = Reserve[i + 1] + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                    else
    //                    {
    //                        current = 5;
    //                        Power = f1.Max() + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                }
    //            }
    //            if (f1.Length == 5)
    //            {
    //                if (Reserve[i] % 4 == f1[0] % 4 && Reserve[i] / 4 > f1.Min() / 4)
    //                {
    //                    current = 5;
    //                    Power = Reserve[i] + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                    vf = true;
    //                }
    //                if (Reserve[i + 1] % 4 == f1[0] % 4 && Reserve[i + 1] / 4 > f1.Min() / 4)
    //                {
    //                    current = 5;
    //                    Power = Reserve[i + 1] + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                    vf = true;
    //                }
    //                else if (Reserve[i] / 4 < f1.Min() / 4 && Reserve[i + 1] / 4 < f1.Min())
    //                {
    //                    current = 5;
    //                    Power = f1.Max() + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                    vf = true;
    //                }
    //            }

    //            if (f2.Length == 3 || f2.Length == 4)
    //            {
    //                if (Reserve[i] % 4 == Reserve[i + 1] % 4 && Reserve[i] % 4 == f2[0] % 4)
    //                {
    //                    if (Reserve[i] / 4 > f2.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = Reserve[i] + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                    if (Reserve[i + 1] / 4 > f2.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = Reserve[i + 1] + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                    else if (Reserve[i] / 4 < f2.Max() / 4 && Reserve[i + 1] / 4 < f2.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = f2.Max() + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                }
    //            }
    //            if (f2.Length == 4)//different cards in hand
    //            {
    //                if (Reserve[i] % 4 != Reserve[i + 1] % 4 && Reserve[i] % 4 == f2[0] % 4)
    //                {
    //                    if (Reserve[i] / 4 > f2.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = Reserve[i] + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                    else
    //                    {
    //                        current = 5;
    //                        Power = f2.Max() + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                }
    //                if (Reserve[i + 1] % 4 != Reserve[i] % 4 && Reserve[i + 1] % 4 == f2[0] % 4)
    //                {
    //                    if (Reserve[i + 1] / 4 > f2.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = Reserve[i + 1] + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                    else
    //                    {
    //                        current = 5;
    //                        Power = f2.Max() + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                }
    //            }
    //            if (f2.Length == 5)
    //            {
    //                if (Reserve[i] % 4 == f2[0] % 4 && Reserve[i] / 4 > f2.Min() / 4)
    //                {
    //                    current = 5;
    //                    Power = Reserve[i] + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                    vf = true;
    //                }
    //                if (Reserve[i + 1] % 4 == f2[0] % 4 && Reserve[i + 1] / 4 > f2.Min() / 4)
    //                {
    //                    current = 5;
    //                    Power = Reserve[i + 1] + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                    vf = true;
    //                }
    //                else if (Reserve[i] / 4 < f2.Min() / 4 && Reserve[i + 1] / 4 < f2.Min())
    //                {
    //                    current = 5;
    //                    Power = f2.Max() + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                    vf = true;
    //                }
    //            }

    //            if (f3.Length == 3 || f3.Length == 4)
    //            {
    //                if (Reserve[i] % 4 == Reserve[i + 1] % 4 && Reserve[i] % 4 == f3[0] % 4)
    //                {
    //                    if (Reserve[i] / 4 > f3.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = Reserve[i] + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                    if (Reserve[i + 1] / 4 > f3.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = Reserve[i + 1] + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                    else if (Reserve[i] / 4 < f3.Max() / 4 && Reserve[i + 1] / 4 < f3.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = f3.Max() + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                }
    //            }
    //            if (f3.Length == 4)//different cards in hand
    //            {
    //                if (Reserve[i] % 4 != Reserve[i + 1] % 4 && Reserve[i] % 4 == f3[0] % 4)
    //                {
    //                    if (Reserve[i] / 4 > f3.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = Reserve[i] + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                    else
    //                    {
    //                        current = 5;
    //                        Power = f3.Max() + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                }
    //                if (Reserve[i + 1] % 4 != Reserve[i] % 4 && Reserve[i + 1] % 4 == f3[0] % 4)
    //                {
    //                    if (Reserve[i + 1] / 4 > f3.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = Reserve[i + 1] + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                    else
    //                    {
    //                        current = 5;
    //                        Power = f3.Max() + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                }
    //            }
    //            if (f3.Length == 5)
    //            {
    //                if (Reserve[i] % 4 == f3[0] % 4 && Reserve[i] / 4 > f3.Min() / 4)
    //                {
    //                    current = 5;
    //                    Power = Reserve[i] + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                    vf = true;
    //                }
    //                if (Reserve[i + 1] % 4 == f3[0] % 4 && Reserve[i + 1] / 4 > f3.Min() / 4)
    //                {
    //                    current = 5;
    //                    Power = Reserve[i + 1] + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                    vf = true;
    //                }
    //                else if (Reserve[i] / 4 < f3.Min() / 4 && Reserve[i + 1] / 4 < f3.Min())
    //                {
    //                    current = 5;
    //                    Power = f3.Max() + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                    vf = true;
    //                }
    //            }

    //            if (f4.Length == 3 || f4.Length == 4)
    //            {
    //                if (Reserve[i] % 4 == Reserve[i + 1] % 4 && Reserve[i] % 4 == f4[0] % 4)
    //                {
    //                    if (Reserve[i] / 4 > f4.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = Reserve[i] + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                    if (Reserve[i + 1] / 4 > f4.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = Reserve[i + 1] + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                    else if (Reserve[i] / 4 < f4.Max() / 4 && Reserve[i + 1] / 4 < f4.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = f4.Max() + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                }
    //            }
    //            if (f4.Length == 4)//different cards in hand
    //            {
    //                if (Reserve[i] % 4 != Reserve[i + 1] % 4 && Reserve[i] % 4 == f4[0] % 4)
    //                {
    //                    if (Reserve[i] / 4 > f4.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = Reserve[i] + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                    else
    //                    {
    //                        current = 5;
    //                        Power = f4.Max() + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                }
    //                if (Reserve[i + 1] % 4 != Reserve[i] % 4 && Reserve[i + 1] % 4 == f4[0] % 4)
    //                {
    //                    if (Reserve[i + 1] / 4 > f4.Max() / 4)
    //                    {
    //                        current = 5;
    //                        Power = Reserve[i + 1] + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                    else
    //                    {
    //                        current = 5;
    //                        Power = f4.Max() + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 5 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                        vf = true;
    //                    }
    //                }
    //            }
    //            if (f4.Length == 5)
    //            {
    //                if (Reserve[i] % 4 == f4[0] % 4 && Reserve[i] / 4 > f4.Min() / 4)
    //                {
    //                    current = 5;
    //                    Power = Reserve[i] + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                    vf = true;
    //                }
    //                if (Reserve[i + 1] % 4 == f4[0] % 4 && Reserve[i + 1] / 4 > f4.Min() / 4)
    //                {
    //                    current = 5;
    //                    Power = Reserve[i + 1] + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                    vf = true;
    //                }
    //                else if (Reserve[i] / 4 < f4.Min() / 4 && Reserve[i + 1] / 4 < f4.Min())
    //                {
    //                    current = 5;
    //                    Power = f4.Max() + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                    vf = true;
    //                }
    //            }
    //            //ace
    //            if (f1.Length > 0)
    //            {
    //                if (Reserve[i] / 4 == 0 && Reserve[i] % 4 == f1[0] % 4 && vf && f1.Length > 0)
    //                {
    //                    current = 5.5;
    //                    Power = 13 + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5.5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                }
    //                if (Reserve[i + 1] / 4 == 0 && Reserve[i + 1] % 4 == f1[0] % 4 && vf && f1.Length > 0)
    //                {
    //                    current = 5.5;
    //                    Power = 13 + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5.5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                }
    //            }
    //            if (f2.Length > 0)
    //            {
    //                if (Reserve[i] / 4 == 0 && Reserve[i] % 4 == f2[0] % 4 && vf && f2.Length > 0)
    //                {
    //                    current = 5.5;
    //                    Power = 13 + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5.5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                }
    //                if (Reserve[i + 1] / 4 == 0 && Reserve[i + 1] % 4 == f2[0] % 4 && vf && f2.Length > 0)
    //                {
    //                    current = 5.5;
    //                    Power = 13 + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5.5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                }
    //            }
    //            if (f3.Length > 0)
    //            {
    //                if (Reserve[i] / 4 == 0 && Reserve[i] % 4 == f3[0] % 4 && vf && f3.Length > 0)
    //                {
    //                    current = 5.5;
    //                    Power = 13 + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5.5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                }
    //                if (Reserve[i + 1] / 4 == 0 && Reserve[i + 1] % 4 == f3[0] % 4 && vf && f3.Length > 0)
    //                {
    //                    current = 5.5;
    //                    Power = 13 + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5.5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                }
    //            }
    //            if (f4.Length > 0)
    //            {
    //                if (Reserve[i] / 4 == 0 && Reserve[i] % 4 == f4[0] % 4 && vf && f4.Length > 0)
    //                {
    //                    current = 5.5;
    //                    Power = 13 + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5.5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                }
    //                if (Reserve[i + 1] / 4 == 0 && Reserve[i + 1] % 4 == f4[0] % 4 && vf)
    //                {
    //                    current = 5.5;
    //                    Power = 13 + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 5.5 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                }
    //            }
    //        }
    //    }
    //    private void CheckForStraight(ref double current, ref double Power, int[] bigStraight)
    //    {
    //        if (current >= -1)
    //        {
    //            var op = bigStraight.Select(o => o / 4).Distinct().ToArray();
    //            for (int j = 0; j < op.Length - 4; j++)
    //            {
    //                if (op[j] + 4 == op[j + 4])
    //                {
    //                    if (op.Max() - 4 == op[j])
    //                    {
    //                        current = 4;
    //                        Power = op.Max() + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 4 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                    }
    //                    else
    //                    {
    //                        current = 4;
    //                        Power = op[j + 4] + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 4 });
    //                        sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                    }
    //                }
    //                if (op[j] == 0 && op[j + 1] == 9 && op[j + 2] == 10 && op[j + 3] == 11 && op[j + 4] == 12)
    //                {
    //                    current = 4;
    //                    Power = 13 + current * 100;
    //                    Win.Add(new Type() { Power = Power, Current = 4 });
    //                    sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //                }
    //            }
    //        }
    //    }
    //    private void CheckForThreeOfAKind(ref double current, ref double Power, int[] bigStraight)
    //    {
    //        if (current >= -1)
    //        {
    //            for (int j = 0; j <= 12; j++)
    //            {
    //                var fh = bigStraight.Where(o => o / 4 == j).ToArray();
    //                if (fh.Length == 3)
    //                {
    //                    if (fh.Max() / 4 == 0)
    //                    {
    //                        current = 3;
    //                        Power = 13 * 3 + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 3 });
    //                        sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
    //                    }
    //                    else
    //                    {
    //                        current = 3;
    //                        Power = fh[0] / 4 + fh[1] / 4 + fh[2] / 4 + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 3 });
    //                        sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    private void CheckForTwoPair(ref double current, ref double Power)
    //    {
    //        if (current >= -1)
    //        {
    //            bool msgbox = false;
    //            for (int tc = 16; tc >= 12; tc--)
    //            {
    //                int max = tc - 12;
    //                if (Reserve[i] / 4 != Reserve[i + 1] / 4)
    //                {
    //                    for (int k = 1; k <= max; k++)
    //                    {
    //                        if (tc - k < 12)
    //                        {
    //                            max--;
    //                        }
    //                        if (tc - k >= 12)
    //                        {
    //                            if (Reserve[i] / 4 == Reserve[tc] / 4 && Reserve[i + 1] / 4 == Reserve[tc - k] / 4 ||
    //                                Reserve[i + 1] / 4 == Reserve[tc] / 4 && Reserve[i] / 4 == Reserve[tc - k] / 4)
    //                            {
    //                                if (!msgbox)
    //                                {
    //                                    if (Reserve[i] / 4 == 0)
    //                                    {
    //                                        current = 2;
    //                                        Power = 13 * 4 + (Reserve[i + 1] / 4) * 2 + current * 100;
    //                                        Win.Add(new Type() { Power = Power, Current = 2 });
    //                                        sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
    //                                    }
    //                                    if (Reserve[i + 1] / 4 == 0)
    //                                    {
    //                                        current = 2;
    //                                        Power = 13 * 4 + (Reserve[i] / 4) * 2 + current * 100;
    //                                        Win.Add(new Type() { Power = Power, Current = 2 });
    //                                        sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
    //                                    }
    //                                    if (Reserve[i + 1] / 4 != 0 && Reserve[i] / 4 != 0)
    //                                    {
    //                                        current = 2;
    //                                        Power = (Reserve[i] / 4) * 2 + (Reserve[i + 1] / 4) * 2 + current * 100;
    //                                        Win.Add(new Type() { Power = Power, Current = 2 });
    //                                        sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
    //                                    }
    //                                }
    //                                msgbox = true;
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    private void CheckForPairTwoPair(ref double current, ref double Power)
    //    {
    //        if (current >= -1)
    //        {
    //            bool msgbox = false;
    //            bool msgbox1 = false;
    //            for (int tc = 16; tc >= 12; tc--)
    //            {
    //                int max = tc - 12;
    //                for (int k = 1; k <= max; k++)
    //                {
    //                    if (tc - k < 12)
    //                    {
    //                        max--;
    //                    }
    //                    if (tc - k >= 12)
    //                    {
    //                        if (Reserve[tc] / 4 == Reserve[tc - k] / 4)
    //                        {
    //                            if (Reserve[tc] / 4 != Reserve[i] / 4 && Reserve[tc] / 4 != Reserve[i + 1] / 4 && current == 1)
    //                            {
    //                                if (!msgbox)
    //                                {
    //                                    if (Reserve[i + 1] / 4 == 0)
    //                                    {
    //                                        current = 2;
    //                                        Power = (Reserve[i] / 4) * 2 + 13 * 4 + current * 100;
    //                                        Win.Add(new Type() { Power = Power, Current = 2 });
    //                                        sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
    //                                    }
    //                                    if (Reserve[i] / 4 == 0)
    //                                    {
    //                                        current = 2;
    //                                        Power = (Reserve[i + 1] / 4) * 2 + 13 * 4 + current * 100;
    //                                        Win.Add(new Type() { Power = Power, Current = 2 });
    //                                        sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
    //                                    }
    //                                    if (Reserve[i + 1] / 4 != 0)
    //                                    {
    //                                        current = 2;
    //                                        Power = (Reserve[tc] / 4) * 2 + (Reserve[i + 1] / 4) * 2 + current * 100;
    //                                        Win.Add(new Type() { Power = Power, Current = 2 });
    //                                        sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
    //                                    }
    //                                    if (Reserve[i] / 4 != 0)
    //                                    {
    //                                        current = 2;
    //                                        Power = (Reserve[tc] / 4) * 2 + (Reserve[i] / 4) * 2 + current * 100;
    //                                        Win.Add(new Type() { Power = Power, Current = 2 });
    //                                        sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
    //                                    }
    //                                }
    //                                msgbox = true;
    //                            }
    //                            if (current == -1)
    //                            {
    //                                if (!msgbox1)
    //                                {
    //                                    if (Reserve[i] / 4 > Reserve[i + 1] / 4)
    //                                    {
    //                                        if (Reserve[tc] / 4 == 0)
    //                                        {
    //                                            current = 0;
    //                                            Power = 13 + Reserve[i] / 4 + current * 100;
    //                                            Win.Add(new Type() { Power = Power, Current = 1 });
    //                                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
    //                                        }
    //                                        else
    //                                        {
    //                                            current = 0;
    //                                            Power = Reserve[tc] / 4 + Reserve[i] / 4 + current * 100;
    //                                            Win.Add(new Type() { Power = Power, Current = 1 });
    //                                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
    //                                        }
    //                                    }
    //                                    else
    //                                    {
    //                                        if (Reserve[tc] / 4 == 0)
    //                                        {
    //                                            current = 0;
    //                                            Power = 13 + Reserve[i + 1] + current * 100;
    //                                            Win.Add(new Type() { Power = Power, Current = 1 });
    //                                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
    //                                        }
    //                                        else
    //                                        {
    //                                            current = 0;
    //                                            Power = Reserve[tc] / 4 + Reserve[i + 1] / 4 + current * 100;
    //                                            Win.Add(new Type() { Power = Power, Current = 1 });
    //                                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
    //                                        }
    //                                    }
    //                                }
    //                                msgbox1 = true;
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    private void CheckForPairFromHand(ref double current, ref double Power)
    //    {
    //        if (current >= -1)
    //        {
    //            bool msgbox = false;
    //            if (Reserve[i] / 4 == Reserve[i + 1] / 4)
    //            {
    //                if (!msgbox)
    //                {
    //                    if (Reserve[i] / 4 == 0)
    //                    {
    //                        current = 1;
    //                        Power = 13 * 4 + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 1 });
    //                        sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
    //                    }
    //                    else
    //                    {
    //                        current = 1;
    //                        Power = (Reserve[i + 1] / 4) * 4 + current * 100;
    //                        Win.Add(new Type() { Power = Power, Current = 1 });
    //                        sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
    //                    }
    //                }
    //                msgbox = true;
    //            }
    //            for (int tc = 16; tc >= 12; tc--)
    //            {
    //                if (Reserve[i + 1] / 4 == Reserve[tc] / 4)
    //                {
    //                    if (!msgbox)
    //                    {
    //                        if (Reserve[i + 1] / 4 == 0)
    //                        {
    //                            current = 1;
    //                            Power = 13 * 4 + Reserve[i] / 4 + current * 100;
    //                            Win.Add(new Type() { Power = Power, Current = 1 });
    //                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
    //                        }
    //                        else
    //                        {
    //                            current = 1;
    //                            Power = (Reserve[i + 1] / 4) * 4 + Reserve[i] / 4 + current * 100;
    //                            Win.Add(new Type() { Power = Power, Current = 1 });
    //                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
    //                        }
    //                    }
    //                    msgbox = true;
    //                }
    //                if (Reserve[i] / 4 == Reserve[tc] / 4)
    //                {
    //                    if (!msgbox)
    //                    {
    //                        if (Reserve[i] / 4 == 0)
    //                        {
    //                            current = 1;
    //                            Power = 13 * 4 + Reserve[i + 1] / 4 + current * 100;
    //                            Win.Add(new Type() { Power = Power, Current = 1 });
    //                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
    //                        }
    //                        else
    //                        {
    //                            current = 1;
    //                            Power = (Reserve[tc] / 4) * 4 + Reserve[i + 1] / 4 + current * 100;
    //                            Win.Add(new Type() { Power = Power, Current = 1 });
    //                            sorted = Win.OrderByDescending(op => op.Current).ThenByDescending(op => op.Power).First();
    //                        }
    //                    }
    //                    msgbox = true;
    //                }
    //            }
    //        }
    //    }
    //    private void CheckForHighCard(ref double current, ref double Power)
    //    {
    //        if (current == -1)
    //        {
    //            if (Reserve[i] / 4 > Reserve[i + 1] / 4)
    //            {
    //                current = -1;
    //                Power = Reserve[i] / 4;
    //                Win.Add(new Type() { Power = Power, Current = -1 });
    //                sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //            }
    //            else
    //            {
    //                current = -1;
    //                Power = Reserve[i + 1] / 4;
    //                Win.Add(new Type() { Power = Power, Current = -1 });
    //                sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //            }
    //            if (Reserve[i] / 4 == 0 || Reserve[i + 1] / 4 == 0)
    //            {
    //                current = -1;
    //                Power = 13;
    //                Win.Add(new Type() { Power = Power, Current = -1 });
    //                sorted = Win.OrderByDescending(op1 => op1.Current).ThenByDescending(op1 => op1.Power).First();
    //            }
    //        }
    //    }

    //    void Winner(double current, double Power, string currentText, int chips, string lastly)
    //    {
    //        if (lastly == " ")
    //        {
    //            lastly = "Bot 5";
    //        }
    //        for (int j = 0; j <= 16; j++)
    //        {
    //            //await Task.Delay(5);
    //            if (lol[j].Visible)
    //                lol[j].Image = Deck[j];
    //        }
    //        if (current == sorted.Current)
    //        {
    //            if (Power == sorted.Power)
    //            {
    //                winners++;
    //                CheckWinners.Add(currentText);
    //                if (current == -1)
    //                {
    //                    MessageBox.Show(currentText + " High Card ");
    //                }
    //                if (current == 1 || current == 0)
    //                {
    //                    MessageBox.Show(currentText + " Pair ");
    //                }
    //                if (current == 2)
    //                {
    //                    MessageBox.Show(currentText + " Two Pair ");
    //                }
    //                if (current == 3)
    //                {
    //                    MessageBox.Show(currentText + " Three of a Kind ");
    //                }
    //                if (current == 4)
    //                {
    //                    MessageBox.Show(currentText + " bigStraight ");
    //                }
    //                if (current == 5 || current == 5.5)
    //                {
    //                    MessageBox.Show(currentText + " Flush ");
    //                }
    //                if (current == 6)
    //                {
    //                    MessageBox.Show(currentText + " Full House ");
    //                }
    //                if (current == 7)
    //                {
    //                    MessageBox.Show(currentText + " Four of a Kind ");
    //                }
    //                if (current == 8)
    //                {
    //                    MessageBox.Show(currentText + " bigStraight Flush ");
    //                }
    //                if (current == 9)
    //                {
    //                    MessageBox.Show(currentText + " Royal Flush ! ");
    //                }
    //            }
    //        }
    //        if (currentText == lastly)//lastfixed
    //        {
    //            if (winners > 1)
    //            {
    //                if (CheckWinners.Contains("Player"))
    //                {
    //                    Chips += int.Parse(tbPot.Text) / winners;
    //                    tbChips.Text = Chips.ToString();
    //                    //playerPanel.Visible = true;

    //                }
    //                if (CheckWinners.Contains("Bot 1"))
    //                {
    //                    bot1Chips += int.Parse(tbPot.Text) / winners;
    //                    tbBotChips1.Text = bot1Chips.ToString();
    //                    //bot1Panel.Visible = true;
    //                }
    //                if (CheckWinners.Contains("Bot 2"))
    //                {
    //                    bot2Chips += int.Parse(tbPot.Text) / winners;
    //                    tbBotChips2.Text = bot2Chips.ToString();
    //                    //bot2Panel.Visible = true;
    //                }
    //                if (CheckWinners.Contains("Bot 3"))
    //                {
    //                    bot3Chips += int.Parse(tbPot.Text) / winners;
    //                    tbBotChips3.Text = bot3Chips.ToString();
    //                    //bot3Panel.Visible = true;
    //                }
    //                if (CheckWinners.Contains("Bot 4"))
    //                {
    //                    bot4Chips += int.Parse(tbPot.Text) / winners;
    //                    tbBotChips4.Text = bot4Chips.ToString();
    //                    //bot4Panel.Visible = true;
    //                }
    //                if (CheckWinners.Contains("Bot 5"))
    //                {
    //                    bot5Chips += int.Parse(tbPot.Text) / winners;
    //                    tbBotChips5.Text = bot5Chips.ToString();
    //                    //bot5Panel.Visible = true;
    //                }
    //                //await Finish(1);
    //            }
    //            if (winners == 1)
    //            {
    //                if (CheckWinners.Contains("Player"))
    //                {
    //                    Chips += int.Parse(tbPot.Text);
    //                    //await Finish(1);
    //                    //playerPanel.Visible = true;
    //                }
    //                if (CheckWinners.Contains("Bot 1"))
    //                {
    //                    bot1Chips += int.Parse(tbPot.Text);
    //                    //await Finish(1);
    //                    //bot1Panel.Visible = true;
    //                }
    //                if (CheckWinners.Contains("Bot 2"))
    //                {
    //                    bot2Chips += int.Parse(tbPot.Text);
    //                    //await Finish(1);
    //                    //bot2Panel.Visible = true;

    //                }
    //                if (CheckWinners.Contains("Bot 3"))
    //                {
    //                    bot3Chips += int.Parse(tbPot.Text);
    //                    //await Finish(1);
    //                    //bot3Panel.Visible = true;
    //                }
    //                if (CheckWinners.Contains("Bot 4"))
    //                {
    //                    bot4Chips += int.Parse(tbPot.Text);
    //                    //await Finish(1);
    //                    //bot4Panel.Visible = true;
    //                }
    //                if (CheckWinners.Contains("Bot 5"))
    //                {
    //                    bot5Chips += int.Parse(tbPot.Text);
    //                    //await Finish(1);
    //                    //bot5Panel.Visible = true;
    //                }
    //            }
    //        }
    //    }
    //    async Task CheckRaise(int currentTurn, int raiseTurn)
    //    {
    //        if (raising)
    //        {
    //            turnCount = 0;
    //            raising = false;
    //            raisedTurn = currentTurn;
    //            changed = true;
    //        }
    //        else
    //        {
    //            if (turnCount >= maxLeft - 1 || !changed && turnCount == maxLeft)
    //            {
    //                if (currentTurn == raisedTurn - 1 || !changed && turnCount == maxLeft || raisedTurn == 0 && currentTurn == 5)
    //                {
    //                    changed = false;
    //                    turnCount = 0;
    //                    Raise = 0;
    //                    call = 0;
    //                    raisedTurn = 123;
    //                    rounds++;
    //                    if (!PFturn)
    //                        pStatus.Text = "";
    //                    if (!B1Fturn)
    //                        b1Status.Text = "";
    //                    if (!B2Fturn)
    //                        b2Status.Text = "";
    //                    if (!B3Fturn)
    //                        b3Status.Text = "";
    //                    if (!B4Fturn)
    //                        b4Status.Text = "";
    //                    if (!B5Fturn)
    //                        b5Status.Text = "";
    //                }
    //            }
    //        }
    //        if (rounds == Flop)
    //        {
    //            for (int j = 12; j <= 14; j++)
    //            {
    //                if (lol[j].Image != Deck[j])
    //                {
    //                    lol[j].Image = Deck[j];
    //                    pCall = 0; pRaise = 0;
    //                    b1Call = 0; b1Raise = 0;
    //                    b2Call = 0; b2Raise = 0;
    //                    b3Call = 0; b3Raise = 0;
    //                    b4Call = 0; b4Raise = 0;
    //                    b5Call = 0; b5Raise = 0;
    //                }
    //            }
    //        }
    //        if (rounds == Turn)
    //        {
    //            for (int j = 14; j <= 15; j++)
    //            {
    //                if (lol[j].Image != Deck[j])
    //                {
    //                    lol[j].Image = Deck[j];
    //                    pCall = 0; pRaise = 0;
    //                    b1Call = 0; b1Raise = 0;
    //                    b2Call = 0; b2Raise = 0;
    //                    b3Call = 0; b3Raise = 0;
    //                    b4Call = 0; b4Raise = 0;
    //                    b5Call = 0; b5Raise = 0;
    //                }
    //            }
    //        }
    //        if (rounds == River)
    //        {
    //            for (int j = 15; j <= 16; j++)
    //            {
    //                if (lol[j].Image != Deck[j])
    //                {
    //                    lol[j].Image = Deck[j];
    //                    pCall = 0; pRaise = 0;
    //                    b1Call = 0; b1Raise = 0;
    //                    b2Call = 0; b2Raise = 0;
    //                    b3Call = 0; b3Raise = 0;
    //                    b4Call = 0; b4Raise = 0;
    //                    b5Call = 0; b5Raise = 0;
    //                }
    //            }
    //        }
    //        if (rounds == End && maxLeft == 6)
    //        {
    //            string fixedLast = "qwerty";
    //            if (!pStatus.Text.Contains("Fold"))
    //            {
    //                fixedLast = "Player";
    //                Rules(0, 1, "Player", ref pType, ref pPower, PFturn);
    //            }
    //            if (!b1Status.Text.Contains("Fold"))
    //            {
    //                fixedLast = "Bot 1";
    //                Rules(2, 3, "Bot 1", ref b1Type, ref b1Power, B1Fturn);
    //            }
    //            if (!b2Status.Text.Contains("Fold"))
    //            {
    //                fixedLast = "Bot 2";
    //                Rules(4, 5, "Bot 2", ref b2Type, ref b2Power, B2Fturn);
    //            }
    //            if (!b3Status.Text.Contains("Fold"))
    //            {
    //                fixedLast = "Bot 3";
    //                Rules(6, 7, "Bot 3", ref b3Type, ref b3Power, B3Fturn);
    //            }
    //            if (!b4Status.Text.Contains("Fold"))
    //            {
    //                fixedLast = "Bot 4";
    //                Rules(8, 9, "Bot 4", ref b4Type, ref b4Power, B4Fturn);
    //            }
    //            if (!b5Status.Text.Contains("Fold"))
    //            {
    //                fixedLast = "Bot 5";
    //                Rules(10, 11, "Bot 5", ref b5Type, ref b5Power, B5Fturn);
    //            }
    //            Winner(pType, pPower, "Player", Chips, fixedLast);
    //            Winner(b1Type, b1Power, "Bot 1", bot1Chips, fixedLast);
    //            Winner(b2Type, b2Power, "Bot 2", bot2Chips, fixedLast);
    //            Winner(b3Type, b3Power, "Bot 3", bot3Chips, fixedLast);
    //            Winner(b4Type, b4Power, "Bot 4", bot4Chips, fixedLast);
    //            Winner(b5Type, b5Power, "Bot 5", bot5Chips, fixedLast);
    //            restart = true;
    //            Pturn = true;
    //            PFturn = false;
    //            B1Fturn = false;
    //            B2Fturn = false;
    //            B3Fturn = false;
    //            B4Fturn = false;
    //            B5Fturn = false;
    //            if (Chips <= 0)
    //            {
    //                AddChips f2 = new AddChips();
    //                f2.ShowDialog();
    //                if (f2.a != 0)
    //                {
    //                    Chips = f2.a;
    //                    bot1Chips += f2.a;
    //                    bot2Chips += f2.a;
    //                    bot3Chips += f2.a;
    //                    bot4Chips += f2.a;
    //                    bot5Chips += f2.a;
    //                    PFturn = false;
    //                    Pturn = true;
    //                    bRaise.Enabled = true;
    //                    bFold.Enabled = true;
    //                    bCheck.Enabled = true;
    //                    bRaise.Text = "Raise";
    //                }
    //            }
    //            playerPanel.Visible = false; bot1Panel.Visible = false; bot2Panel.Visible = false; bot3Panel.Visible = false; bot4Panel.Visible = false; bot5Panel.Visible = false;
    //            pCall = 0; pRaise = 0;
    //            b1Call = 0; b1Raise = 0;
    //            b2Call = 0; b2Raise = 0;
    //            b3Call = 0; b3Raise = 0;
    //            b4Call = 0; b4Raise = 0;
    //            b5Call = 0; b5Raise = 0;
    //            last = 0;
    //            call = bigBlind;
    //            Raise = 0;
    //            ImgLocation = Directory.GetFiles("Assets\\Cards", "*.png", SearchOption.TopDirectoryOnly);
    //            bools.Clear();
    //            rounds = 0;
    //            pPower = 0; pType = -1;
    //            type = 0; b1Power = 0; b2Power = 0; b3Power = 0; b4Power = 0; b5Power = 0;
    //            b1Type = -1; b2Type = -1; b3Type = -1; b4Type = -1; b5Type = -1;
    //            ints.Clear();
    //            CheckWinners.Clear();
    //            winners = 0;
    //            Win.Clear();
    //            sorted.Current = 0;
    //            sorted.Power = 0;
    //            for (int os = 0; os < 17; os++)
    //            {
    //                lol[os].Image = null;
    //                lol[os].Invalidate();
    //                lol[os].Visible = false;
    //            }
    //            tbPot.Text = "0";
    //            pStatus.Text = "";
    //            await Shuffle();
    //            await Turns();
    //        }
    //    }
    //    void FixCall(Label status, ref int cCall, ref int cRaise, int options)
    //    {
    //        if (rounds != 4)
    //        {
    //            if (options == 1)
    //            {
    //                if (status.Text.Contains("Raise"))
    //                {
    //                    var changeRaise = status.Text.Substring(6);
    //                    cRaise = int.Parse(changeRaise);
    //                }
    //                if (status.Text.Contains("Call"))
    //                {
    //                    var changeCall = status.Text.Substring(5);
    //                    cCall = int.Parse(changeCall);
    //                }
    //                if (status.Text.Contains("Check"))
    //                {
    //                    cRaise = 0;
    //                    cCall = 0;
    //                }
    //            }
    //            if (options == 2)
    //            {
    //                if (cRaise != Raise && cRaise <= Raise)
    //                {
    //                    call = Convert.ToInt32(Raise) - cRaise;
    //                }
    //                if (cCall != call || cCall <= call)
    //                {
    //                    call = call - cCall;
    //                }
    //                if (cRaise == Raise && Raise > 0)
    //                {
    //                    call = 0;
    //                    bCall.Enabled = false;
    //                    bCall.Text = "Callisfuckedup";
    //                }
    //            }
    //        }
    //    }
    //    async Task AllIn()
    //    {
    //        #region All in
    //        if (Chips <= 0 && !intsadded)
    //        {
    //            if (pStatus.Text.Contains("Raise"))
    //            {
    //                ints.Add(Chips);
    //                intsadded = true;
    //            }
    //            if (pStatus.Text.Contains("Call"))
    //            {
    //                ints.Add(Chips);
    //                intsadded = true;
    //            }
    //        }
    //        intsadded = false;
    //        if (bot1Chips <= 0 && !B1Fturn)
    //        {
    //            if (!intsadded)
    //            {
    //                ints.Add(bot1Chips);
    //                intsadded = true;
    //            }
    //            intsadded = false;
    //        }
    //        if (bot2Chips <= 0 && !B2Fturn)
    //        {
    //            if (!intsadded)
    //            {
    //                ints.Add(bot2Chips);
    //                intsadded = true;
    //            }
    //            intsadded = false;
    //        }
    //        if (bot3Chips <= 0 && !B3Fturn)
    //        {
    //            if (!intsadded)
    //            {
    //                ints.Add(bot3Chips);
    //                intsadded = true;
    //            }
    //            intsadded = false;
    //        }
    //        if (bot4Chips <= 0 && !B4Fturn)
    //        {
    //            if (!intsadded)
    //            {
    //                ints.Add(bot4Chips);
    //                intsadded = true;
    //            }
    //            intsadded = false;
    //        }
    //        if (bot5Chips <= 0 && !B5Fturn)
    //        {
    //            if (!intsadded)
    //            {
    //                ints.Add(bot5Chips);
    //                intsadded = true;
    //            }
    //        }
    //        if (ints.ToArray().Length == maxLeft)
    //        {
    //            await Finish(2);
    //        }
    //        else
    //        {
    //            ints.Clear();
    //        }
    //        #endregion

    //        var abc = bools.Count(x => x == false);

    //        #region LastManStanding
    //        if (abc == 1)
    //        {
    //            int index = bools.IndexOf(false);
    //            if (index == 0)
    //            {
    //                Chips += int.Parse(tbPot.Text);
    //                tbChips.Text = Chips.ToString();
    //                playerPanel.Visible = true;
    //                MessageBox.Show("Player Wins");
    //            }
    //            if (index == 1)
    //            {
    //                bot1Chips += int.Parse(tbPot.Text);
    //                tbChips.Text = bot1Chips.ToString();
    //                bot1Panel.Visible = true;
    //                MessageBox.Show("Bot 1 Wins");
    //            }
    //            if (index == 2)
    //            {
    //                bot2Chips += int.Parse(tbPot.Text);
    //                tbChips.Text = bot2Chips.ToString();
    //                bot2Panel.Visible = true;
    //                MessageBox.Show("Bot 2 Wins");
    //            }
    //            if (index == 3)
    //            {
    //                bot3Chips += int.Parse(tbPot.Text);
    //                tbChips.Text = bot3Chips.ToString();
    //                bot3Panel.Visible = true;
    //                MessageBox.Show("Bot 3 Wins");
    //            }
    //            if (index == 4)
    //            {
    //                bot4Chips += int.Parse(tbPot.Text);
    //                tbChips.Text = bot4Chips.ToString();
    //                bot4Panel.Visible = true;
    //                MessageBox.Show("Bot 4 Wins");
    //            }
    //            if (index == 5)
    //            {
    //                bot5Chips += int.Parse(tbPot.Text);
    //                tbChips.Text = bot5Chips.ToString();
    //                bot5Panel.Visible = true;
    //                MessageBox.Show("Bot 5 Wins");
    //            }
    //            for (int j = 0; j <= 16; j++)
    //            {
    //                lol[j].Visible = false;
    //            }
    //            await Finish(1);
    //        }
    //        intsadded = false;
    //        #endregion

    //        #region FiveOrLessLeft
    //        if (abc < 6 && abc > 1 && rounds >= End)
    //        {
    //            await Finish(2);
    //        }
    //        #endregion


    //    }
    //    async Task Finish(int n)
    //    {
    //        if (n == 2)
    //        {
    //            FixWinners();
    //        }
    //        playerPanel.Visible = false; bot1Panel.Visible = false; bot2Panel.Visible = false; bot3Panel.Visible = false; bot4Panel.Visible = false; bot5Panel.Visible = false;
    //        call = bigBlind; Raise = 0;
    //        foldedPlayers = 5;
    //        type = 0; rounds = 0; b1Power = 0; b2Power = 0; b3Power = 0; b4Power = 0; b5Power = 0; pPower = 0; pType = -1; Raise = 0;
    //        b1Type = -1; b2Type = -1; b3Type = -1; b4Type = -1; b5Type = -1;
    //        B1turn = false; B2turn = false; B3turn = false; B4turn = false; B5turn = false;
    //        B1Fturn = false; B2Fturn = false; B3Fturn = false; B4Fturn = false; B5Fturn = false;
    //        pFolded = false; b1Folded = false; b2Folded = false; b3Folded = false; b4Folded = false; b5Folded = false;
    //        PFturn = false; Pturn = true; restart = false; raising = false;
    //        pCall = 0; b1Call = 0; b2Call = 0; b3Call = 0; b4Call = 0; b5Call = 0; pRaise = 0; b1Raise = 0; b2Raise = 0; b3Raise = 0; b4Raise = 0; b5Raise = 0;
    //        height = 0; width = 0; winners = 0; Flop = 1; Turn = 2; River = 3; End = 4; maxLeft = 6;
    //        last = 123; raisedTurn = 1;
    //        bools.Clear();
    //        CheckWinners.Clear();
    //        ints.Clear();
    //        Win.Clear();
    //        sorted.Current = 0;
    //        sorted.Power = 0;
    //        tbPot.Text = "0";
    //        timeRemaining = 60; up = 10000000; turnCount = 0;
    //        pStatus.Text = "";
    //        b1Status.Text = "";
    //        b2Status.Text = "";
    //        b3Status.Text = "";
    //        b4Status.Text = "";
    //        b5Status.Text = "";
    //        if (Chips <= 0)
    //        {
    //            AddChips f2 = new AddChips();
    //            f2.ShowDialog();
    //            if (f2.a != 0)
    //            {
    //                Chips = f2.a;
    //                bot1Chips += f2.a;
    //                bot2Chips += f2.a;
    //                bot3Chips += f2.a;
    //                bot4Chips += f2.a;
    //                bot5Chips += f2.a;
    //                PFturn = false;
    //                Pturn = true;
    //                bRaise.Enabled = true;
    //                bFold.Enabled = true;
    //                bCheck.Enabled = true;
    //                bRaise.Text = "Raise";
    //            }
    //        }
    //        ImgLocation = Directory.GetFiles("Assets\\Cards", "*.png", SearchOption.TopDirectoryOnly);
    //        for (int os = 0; os < 17; os++)
    //        {
    //            lol[os].Image = null;
    //            lol[os].Invalidate();
    //            lol[os].Visible = false;
    //        }
    //        await Shuffle();
    //        //await Turns();
    //    }
    //    void FixWinners()
    //    {
    //        Win.Clear();
    //        sorted.Current = 0;
    //        sorted.Power = 0;
    //        string fixedLast = "qwerty";
    //        if (!pStatus.Text.Contains("Fold"))
    //        {
    //            fixedLast = "Player";
    //            Rules(0, 1, "Player", ref pType, ref pPower, PFturn);
    //        }
    //        if (!b1Status.Text.Contains("Fold"))
    //        {
    //            fixedLast = "Bot 1";
    //            Rules(2, 3, "Bot 1", ref b1Type, ref b1Power, B1Fturn);
    //        }
    //        if (!b2Status.Text.Contains("Fold"))
    //        {
    //            fixedLast = "Bot 2";
    //            Rules(4, 5, "Bot 2", ref b2Type, ref b2Power, B2Fturn);
    //        }
    //        if (!b3Status.Text.Contains("Fold"))
    //        {
    //            fixedLast = "Bot 3";
    //            Rules(6, 7, "Bot 3", ref b3Type, ref b3Power, B3Fturn);
    //        }
    //        if (!b4Status.Text.Contains("Fold"))
    //        {
    //            fixedLast = "Bot 4";
    //            Rules(8, 9, "Bot 4", ref b4Type, ref b4Power, B4Fturn);
    //        }
    //        if (!b5Status.Text.Contains("Fold"))
    //        {
    //            fixedLast = "Bot 5";
    //            Rules(10, 11, "Bot 5", ref b5Type, ref b5Power, B5Fturn);
    //        }
    //        Winner(pType, pPower, "Player", Chips, fixedLast);
    //        Winner(b1Type, b1Power, "Bot 1", bot1Chips, fixedLast);
    //        Winner(b2Type, b2Power, "Bot 2", bot2Chips, fixedLast);
    //        Winner(b3Type, b3Power, "Bot 3", bot3Chips, fixedLast);
    //        Winner(b4Type, b4Power, "Bot 4", bot4Chips, fixedLast);
    //        Winner(b5Type, b5Power, "Bot 5", bot5Chips, fixedLast);
    //    }
    //    void AI(int cardOne, int cardTwo, ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, int name, double botPower, double botCurrent)
    //    {
    //        if (!sFTurn)
    //        {
    //            if (botCurrent == -1)
    //            {
    //                HighCard(ref sChips, ref sTurn, ref sFTurn, sStatus, botPower);
    //            }
    //            if (botCurrent == 0)
    //            {
    //                PairTable(ref sChips, ref sTurn, ref sFTurn, sStatus, botPower);
    //            }
    //            if (botCurrent == 1)
    //            {
    //                PairHand(ref sChips, ref sTurn, ref sFTurn, sStatus, botPower);
    //            }
    //            if (botCurrent == 2)
    //            {
    //                TwoPair(ref sChips, ref sTurn, ref sFTurn, sStatus, botPower);
    //            }
    //            if (botCurrent == 3)
    //            {
    //                ThreeOfAKind(ref sChips, ref sTurn, ref sFTurn, sStatus, name, botPower);
    //            }
    //            if (botCurrent == 4)
    //            {
    //                Straight(ref sChips, ref sTurn, ref sFTurn, sStatus, name, botPower);
    //            }
    //            if (botCurrent == 5 || botCurrent == 5.5)
    //            {
    //                Flush(ref sChips, ref sTurn, ref sFTurn, sStatus, name, botPower);
    //            }
    //            if (botCurrent == 6)
    //            {
    //                FullHouse(ref sChips, ref sTurn, ref sFTurn, sStatus, name, botPower);
    //            }
    //            if (botCurrent == 7)
    //            {
    //                FourOfAKind(ref sChips, ref sTurn, ref sFTurn, sStatus, name, botPower);
    //            }
    //            if (botCurrent == 8 || botCurrent == 9)
    //            {
    //                bigStraightFlush(ref sChips, ref sTurn, ref sFTurn, sStatus, name, botPower);
    //            }
    //        }
    //        if (sFTurn)
    //        {
    //            lol[cardOne].Visible = false;
    //            lol[cardTwo].Visible = false;
    //        }
    //    }

    //    private void HighCard(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, double botPower)
    //    {
    //        HP(ref sChips, ref sTurn, ref sFTurn, sStatus, botPower, 20, 25);
    //    }
    //    private void PairTable(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, double botPower)
    //    {
    //        HP(ref sChips, ref sTurn, ref sFTurn, sStatus, botPower, 16, 25);
    //    }
    //    private void PairHand(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, double botPower)
    //    {
    //        Random rPair = new Random();
    //        int rCall = rPair.Next(10, 16);
    //        int rRaise = rPair.Next(10, 13);
    //        if (botPower <= 199 && botPower >= 140)
    //        {
    //            PH(ref sChips, ref sTurn, ref sFTurn, sStatus, rCall, 6, rRaise);
    //        }
    //        if (botPower <= 139 && botPower >= 128)
    //        {
    //            PH(ref sChips, ref sTurn, ref sFTurn, sStatus, rCall, 7, rRaise);
    //        }
    //        if (botPower < 128 && botPower >= 101)
    //        {
    //            PH(ref sChips, ref sTurn, ref sFTurn, sStatus, rCall, 9, rRaise);
    //        }
    //    }
    //    private void TwoPair(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, double botPower)
    //    {
    //        Random rPair = new Random();
    //        int rCall = rPair.Next(6, 11);
    //        int rRaise = rPair.Next(6, 11);
    //        if (botPower <= 290 && botPower >= 246)
    //        {
    //            PH(ref sChips, ref sTurn, ref sFTurn, sStatus, rCall, 3, rRaise);
    //        }
    //        if (botPower <= 244 && botPower >= 234)
    //        {
    //            PH(ref sChips, ref sTurn, ref sFTurn, sStatus, rCall, 4, rRaise);
    //        }
    //        if (botPower < 234 && botPower >= 201)
    //        {
    //            PH(ref sChips, ref sTurn, ref sFTurn, sStatus, rCall, 4, rRaise);
    //        }
    //    }
    //    private void ThreeOfAKind(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, int name, double botPower)
    //    {
    //        Random tk = new Random();
    //        int tCall = tk.Next(3, 7);
    //        int tRaise = tk.Next(4, 8);
    //        if (botPower <= 390 && botPower >= 330)
    //        {
    //            Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, tCall, tRaise);
    //        }
    //        if (botPower <= 327 && botPower >= 321)//10  8
    //        {
    //            Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, tCall, tRaise);
    //        }
    //        if (botPower < 321 && botPower >= 303)//7 2
    //        {
    //            Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, tCall, tRaise);
    //        }
    //    }
    //    private void Straight(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, int name, double botPower)
    //    {
    //        Random str = new Random();
    //        int sCall = str.Next(3, 6);
    //        int sRaise = str.Next(3, 8);
    //        if (botPower <= 480 && botPower >= 410)
    //        {
    //            Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, sCall, sRaise);
    //        }
    //        if (botPower <= 409 && botPower >= 407)//10  8
    //        {
    //            Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, sCall, sRaise);
    //        }
    //        if (botPower < 407 && botPower >= 404)
    //        {
    //            Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, sCall, sRaise);
    //        }
    //    }
    //    private void Flush(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, int name, double botPower)
    //    {
    //        Random fsh = new Random();
    //        int fCall = fsh.Next(2, 6);
    //        int fRaise = fsh.Next(3, 7);
    //        Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, fCall, fRaise);
    //    }
    //    private void FullHouse(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, int name, double botPower)
    //    {
    //        Random flh = new Random();
    //        int fhCall = flh.Next(1, 5);
    //        int fhRaise = flh.Next(2, 6);
    //        if (botPower <= 626 && botPower >= 620)
    //        {
    //            Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, fhCall, fhRaise);
    //        }
    //        if (botPower < 620 && botPower >= 602)
    //        {
    //            Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, fhCall, fhRaise);
    //        }
    //    }
    //    private void FourOfAKind(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, int name, double botPower)
    //    {
    //        Random fk = new Random();
    //        int fkCall = fk.Next(1, 4);
    //        int fkRaise = fk.Next(2, 5);
    //        if (botPower <= 752 && botPower >= 704)
    //        {
    //            Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, fkCall, fkRaise);
    //        }
    //    }
    //    private void bigStraightFlush(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, int name, double botPower)
    //    {
    //        Random sf = new Random();
    //        int sfCall = sf.Next(1, 3);
    //        int sfRaise = sf.Next(1, 3);
    //        if (botPower <= 913 && botPower >= 804)
    //        {
    //            Smooth(ref sChips, ref sTurn, ref sFTurn, sStatus, name, sfCall, sfRaise);
    //        }
    //    }

    //    private void Fold(ref bool sTurn, ref bool sFTurn, Label sStatus)
    //    {
    //        raising = false;
    //        sStatus.Text = "Fold";
    //        sTurn = false;
    //        sFTurn = true;
    //    }
    //    private void Check(ref bool cTurn, Label cStatus)
    //    {
    //        cStatus.Text = "Check";
    //        cTurn = false;
    //        raising = false;
    //    }
    //    private void Call(ref int sChips, ref bool sTurn, Label sStatus)
    //    {
    //        raising = false;
    //        sTurn = false;
    //        sChips -= call;
    //        sStatus.Text = "Call " + call;
    //        tbPot.Text = (int.Parse(tbPot.Text) + call).ToString();
    //    }
    //    private void Raised(ref int sChips, ref bool sTurn, Label sStatus)
    //    {
    //        sChips -= Convert.ToInt32(Raise);
    //        sStatus.Text = "Raise " + Raise;
    //        tbPot.Text = (int.Parse(tbPot.Text) + Convert.ToInt32(Raise)).ToString();
    //        call = Convert.ToInt32(Raise);
    //        raising = true;
    //        sTurn = false;
    //    }

    //    private static double RoundN(int sChips, int n)
    //    {
    //        double a = Math.Round((sChips / n) / 100d, 0) * 100;
    //        return a;
    //    }
    //    private void HP(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, double botPower, int n, int n1)
    //    {
    //        Random rand = new Random();
    //        int rnd = rand.Next(1, 4);
    //        if (call <= 0)
    //        {
    //            Check(ref sTurn, sStatus);
    //        }
    //        if (call > 0)
    //        {
    //            if (rnd == 1)
    //            {
    //                if (call <= RoundN(sChips, n))
    //                {
    //                    Call(ref sChips, ref sTurn, sStatus);
    //                }
    //                else
    //                {
    //                    Fold(ref sTurn, ref sFTurn, sStatus);
    //                }
    //            }
    //            if (rnd == 2)
    //            {
    //                if (call <= RoundN(sChips, n1))
    //                {
    //                    Call(ref sChips, ref sTurn, sStatus);
    //                }
    //                else
    //                {
    //                    Fold(ref sTurn, ref sFTurn, sStatus);
    //                }
    //            }
    //        }
    //        if (rnd == 3)
    //        {
    //            if (Raise == 0)
    //            {
    //                Raise = call * 2;
    //                Raised(ref sChips, ref sTurn, sStatus);
    //            }
    //            else
    //            {
    //                if (Raise <= RoundN(sChips, n))
    //                {
    //                    Raise = call * 2;
    //                    Raised(ref sChips, ref sTurn, sStatus);
    //                }
    //                else
    //                {
    //                    Fold(ref sTurn, ref sFTurn, sStatus);
    //                }
    //            }
    //        }
    //        if (sChips <= 0)
    //        {
    //            sFTurn = true;
    //        }
    //    }
    //    private void PH(ref int sChips, ref bool sTurn, ref bool sFTurn, Label sStatus, int n, int n1, int r)
    //    {
    //        Random rand = new Random();
    //        int rnd = rand.Next(1, 3);
    //        if (rounds < 2)
    //        {
    //            if (call <= 0)
    //            {
    //                Check(ref sTurn, sStatus);
    //            }
    //            if (call > 0)
    //            {
    //                if (call >= RoundN(sChips, n1))
    //                {
    //                    Fold(ref sTurn, ref sFTurn, sStatus);
    //                }
    //                if (Raise > RoundN(sChips, n))
    //                {
    //                    Fold(ref sTurn, ref sFTurn, sStatus);
    //                }
    //                if (!sFTurn)
    //                {
    //                    if (call >= RoundN(sChips, n) && call <= RoundN(sChips, n1))
    //                    {
    //                        Call(ref sChips, ref sTurn, sStatus);
    //                    }
    //                    if (Raise <= RoundN(sChips, n) && Raise >= (RoundN(sChips, n)) / 2)
    //                    {
    //                        Call(ref sChips, ref sTurn, sStatus);
    //                    }
    //                    if (Raise <= (RoundN(sChips, n)) / 2)
    //                    {
    //                        if (Raise > 0)
    //                        {
    //                            Raise = RoundN(sChips, n);
    //                            Raised(ref sChips, ref sTurn, sStatus);
    //                        }
    //                        else
    //                        {
    //                            Raise = call * 2;
    //                            Raised(ref sChips, ref sTurn, sStatus);
    //                        }
    //                    }

    //                }
    //            }
    //        }
    //        if (rounds >= 2)
    //        {
    //            if (call > 0)
    //            {
    //                if (call >= RoundN(sChips, n1 - rnd))
    //                {
    //                    Fold(ref sTurn, ref sFTurn, sStatus);
    //                }
    //                if (Raise > RoundN(sChips, n - rnd))
    //                {
    //                    Fold(ref sTurn, ref sFTurn, sStatus);
    //                }
    //                if (!sFTurn)
    //                {
    //                    if (call >= RoundN(sChips, n - rnd) && call <= RoundN(sChips, n1 - rnd))
    //                    {
    //                        Call(ref sChips, ref sTurn, sStatus);
    //                    }
    //                    if (Raise <= RoundN(sChips, n - rnd) && Raise >= (RoundN(sChips, n - rnd)) / 2)
    //                    {
    //                        Call(ref sChips, ref sTurn, sStatus);
    //                    }
    //                    if (Raise <= (RoundN(sChips, n - rnd)) / 2)
    //                    {
    //                        if (Raise > 0)
    //                        {
    //                            Raise = RoundN(sChips, n - rnd);
    //                            Raised(ref sChips, ref sTurn, sStatus);
    //                        }
    //                        else
    //                        {
    //                            Raise = call * 2;
    //                            Raised(ref sChips, ref sTurn, sStatus);
    //                        }
    //                    }
    //                }
    //            }
    //            if (call <= 0)
    //            {
    //                Raise = RoundN(sChips, r - rnd);
    //                Raised(ref sChips, ref sTurn, sStatus);
    //            }
    //        }
    //        if (sChips <= 0)
    //        {
    //            sFTurn = true;
    //        }
    //    }
    //    void Smooth(ref int botChips, ref bool botTurn, ref bool botFTurn, Label botStatus, int name, int n, int r)
    //    {
    //        Random rand = new Random();
    //        int rnd = rand.Next(1, 3);
    //        if (call <= 0)
    //        {
    //            Check(ref botTurn, botStatus);
    //        }
    //        else
    //        {
    //            if (call >= RoundN(botChips, n))
    //            {
    //                if (botChips > call)
    //                {
    //                    Call(ref botChips, ref botTurn, botStatus);
    //                }
    //                else if (botChips <= call)
    //                {
    //                    raising = false;
    //                    botTurn = false;
    //                    botChips = 0;
    //                    botStatus.Text = "Call " + botChips;
    //                    tbPot.Text = (int.Parse(tbPot.Text) + botChips).ToString();
    //                }
    //            }
    //            else
    //            {
    //                if (Raise > 0)
    //                {
    //                    if (botChips >= Raise * 2)
    //                    {
    //                        Raise *= 2;
    //                        Raised(ref botChips, ref botTurn, botStatus);
    //                    }
    //                    else
    //                    {
    //                        Call(ref botChips, ref botTurn, botStatus);
    //                    }
    //                }
    //                else
    //                {
    //                    Raise = call * 2;
    //                    Raised(ref botChips, ref botTurn, botStatus);
    //                }
    //            }
    //        }
    //        if (botChips <= 0)
    //        {
    //            botFTurn = true;
    //        }
    //    }

    //    #region UI
    //    private async void timer_Tick(object sender, object e)
    //    {
    //        if (pbTimer.Value <= 0)
    //        {
    //            PFturn = true;
    //            await Turns();
    //        }
    //        if (timeRemaining > 0)
    //        {
    //            timeRemaining--;
    //            pbTimer.Value = (timeRemaining / 6) * 100;
    //        }
    //    }
    //    private void Update_Tick(object sender, object e)
    //    {
    //        if (Chips <= 0)
    //        {
    //            tbChips.Text = "Chips : 0";
    //        }
    //        if (bot1Chips <= 0)
    //        {
    //            tbBotChips1.Text = "Chips : 0";
    //        }
    //        if (bot2Chips <= 0)
    //        {
    //            tbBotChips2.Text = "Chips : 0";
    //        }
    //        if (bot3Chips <= 0)
    //        {
    //            tbBotChips3.Text = "Chips : 0";
    //        }
    //        if (bot4Chips <= 0)
    //        {
    //            tbBotChips4.Text = "Chips : 0";
    //        }
    //        if (bot5Chips <= 0)
    //        {
    //            tbBotChips5.Text = "Chips : 0";
    //        }
    //        tbChips.Text = "Chips : " + Chips.ToString();
    //        tbBotChips1.Text = "Chips : " + bot1Chips.ToString();
    //        tbBotChips2.Text = "Chips : " + bot2Chips.ToString();
    //        tbBotChips3.Text = "Chips : " + bot3Chips.ToString();
    //        tbBotChips4.Text = "Chips : " + bot4Chips.ToString();
    //        tbBotChips5.Text = "Chips : " + bot5Chips.ToString();
    //        if (Chips <= 0)
    //        {
    //            Pturn = false;
    //            PFturn = true;
    //            bCall.Enabled = false;
    //            bRaise.Enabled = false;
    //            bFold.Enabled = false;
    //            bCheck.Enabled = false;
    //        }
    //        if (up > 0)
    //        {
    //            up--;
    //        }
    //        if (Chips >= call)
    //        {
    //            bCall.Text = "Call " + call.ToString();
    //        }
    //        else
    //        {
    //            bCall.Text = "All in";
    //            bRaise.Enabled = false;
    //        }
    //        if (call > 0)
    //        {
    //            bCheck.Enabled = false;
    //        }
    //        if (call <= 0)
    //        {
    //            bCheck.Enabled = true;
    //            bCall.Text = "Call";
    //            bCall.Enabled = false;
    //        }
    //        if (Chips <= 0)
    //        {
    //            bRaise.Enabled = false;
    //        }
    //        int parsedValue;

    //        if (textBoxRaise.Text != "" && int.TryParse(textBoxRaise.Text, out parsedValue))
    //        {
    //            if (Chips <= int.Parse(textBoxRaise.Text))
    //            {
    //                bRaise.Text = "All in";
    //            }
    //            else
    //            {
    //                bRaise.Text = "Raise";
    //            }
    //        }
    //        if (Chips < call)
    //        {
    //            bRaise.Enabled = false;
    //        }
    //    }
    //    private async void bFold_Click(object sender, EventArgs e)
    //    {
    //        pStatus.Text = "Fold";
    //        Pturn = false;
    //        PFturn = true;
    //        await Turns();
    //    }
    //    private async void bCheck_Click(object sender, EventArgs e)
    //    {
    //        if (call <= 0)
    //        {
    //            Pturn = false;
    //            pStatus.Text = "Check";
    //        }
    //        else
    //        {
    //            //pStatus.Text = "All in " + Chips;

    //            bCheck.Enabled = false;
    //        }
    //        await Turns();
    //    }
    //    private async void bCall_Click(object sender, EventArgs e)
    //    {
    //        Rules(0, 1, "Player", ref pType, ref pPower, PFturn);
    //        if (Chips >= call)
    //        {
    //            Chips -= call;
    //            tbChips.Text = "Chips : " + Chips.ToString();
    //            if (tbPot.Text != "")
    //            {
    //                tbPot.Text = (int.Parse(tbPot.Text) + call).ToString();
    //            }
    //            else
    //            {
    //                tbPot.Text = call.ToString();
    //            }
    //            Pturn = false;
    //            pStatus.Text = "Call " + call;
    //            pCall = call;
    //        }
    //        else if (Chips <= call && call > 0)
    //        {
    //            tbPot.Text = (int.Parse(tbPot.Text) + Chips).ToString();
    //            pStatus.Text = "All in " + Chips;
    //            Chips = 0;
    //            tbChips.Text = "Chips : " + Chips.ToString();
    //            Pturn = false;
    //            bFold.Enabled = false;
    //            pCall = Chips;
    //        }
    //        await Turns();
    //    }
    //    private async void bRaise_Click(object sender, EventArgs e)
    //    {
    //        Rules(0, 1, "Player", ref pType, ref pPower, PFturn);
    //        int parsedValue;
    //        if (textBoxRaise.Text != "" && int.TryParse(textBoxRaise.Text, out parsedValue))
    //        {
    //            if (Chips > call)
    //            {
    //                if (Raise * 2 > int.Parse(textBoxRaise.Text))
    //                {
    //                    textBoxRaise.Text = (Raise * 2).ToString();
    //                    MessageBox.Show("You must raise atleast twice as the curentCardsValue raise !");
    //                    return;
    //                }
    //                else
    //                {
    //                    if (Chips >= int.Parse(textBoxRaise.Text))
    //                    {
    //                        call = int.Parse(textBoxRaise.Text);
    //                        Raise = int.Parse(textBoxRaise.Text);
    //                        pStatus.Text = "Raise " + call.ToString();
    //                        tbPot.Text = (int.Parse(tbPot.Text) + call).ToString();
    //                        bCall.Text = "Call";
    //                        Chips -= int.Parse(textBoxRaise.Text);
    //                        raising = true;
    //                        last = 0;
    //                        pRaise = Convert.ToInt32(Raise);
    //                    }
    //                    else
    //                    {
    //                        call = Chips;
    //                        Raise = Chips;
    //                        tbPot.Text = (int.Parse(tbPot.Text) + Chips).ToString();
    //                        pStatus.Text = "Raise " + call.ToString();
    //                        Chips = 0;
    //                        raising = true;
    //                        last = 0;
    //                        pRaise = Convert.ToInt32(Raise);
    //                    }
    //                }
    //            }
    //        }
    //        else
    //        {
    //            MessageBox.Show("This is a number only field");
    //            return;
    //        }
    //        Pturn = false;
    //        await Turns();
    //    }
    //    private void bAdd_Click(object sender, EventArgs e)
    //    {
    //        if (tbAdd.Text == "") { }
    //        else
    //        {
    //            Chips += int.Parse(tbAdd.Text);
    //            bot1Chips += int.Parse(tbAdd.Text);
    //            bot2Chips += int.Parse(tbAdd.Text);
    //            bot3Chips += int.Parse(tbAdd.Text);
    //            bot4Chips += int.Parse(tbAdd.Text);
    //            bot5Chips += int.Parse(tbAdd.Text);
    //        }
    //        tbChips.Text = "Chips : " + Chips.ToString();
    //    }
    //    private void bOptions_Click(object sender, EventArgs e)
    //    {
    //        textBoxBigBlind.Text = bigBlind.ToString();
    //        textBoxSmallBlind.Text = smallBlind.ToString();
    //        if (textBoxBigBlind.Visible == false)
    //        {
    //            textBoxBigBlind.Visible = true;
    //            textBoxSmallBlind.Visible = true;
    //            buttonBigBlind.Visible = true;
    //            buttonSmallBlind.Visible = true;
    //        }
    //        else
    //        {
    //            textBoxBigBlind.Visible = false;
    //            textBoxSmallBlind.Visible = false;
    //            buttonBigBlind.Visible = false;
    //            buttonSmallBlind.Visible = false;
    //        }
    //    }
    //    private void bSB_Click(object sender, EventArgs e)
    //    {
    //        int parsedValue;
    //        if (textBoxSmallBlind.Text.Contains(",") || textBoxSmallBlind.Text.Contains("."))
    //        {
    //            MessageBox.Show("The Small Blind can be only round number !");
    //            textBoxSmallBlind.Text = smallBlind.ToString();
    //            return;
    //        }
    //        if (!int.TryParse(textBoxSmallBlind.Text, out parsedValue))
    //        {
    //            MessageBox.Show("This is a number only field");
    //            textBoxSmallBlind.Text = smallBlind.ToString();
    //            return;
    //        }
    //        if (int.Parse(textBoxSmallBlind.Text) > 100000)
    //        {
    //            MessageBox.Show("The maximum of the Small Blind is 100 000 $");
    //            textBoxSmallBlind.Text = smallBlind.ToString();
    //        }
    //        if (int.Parse(textBoxSmallBlind.Text) < 250)
    //        {
    //            MessageBox.Show("The minimum of the Small Blind is 250 $");
    //        }
    //        if (int.Parse(textBoxSmallBlind.Text) >= 250 && int.Parse(textBoxSmallBlind.Text) <= 100000)
    //        {
    //            smallBlind = int.Parse(textBoxSmallBlind.Text);
    //            MessageBox.Show("The changes have been saved ! They will become available the next hand you play. ");
    //        }
    //    }
    //    private void bBB_Click(object sender, EventArgs e)
    //    {
    //        int parsedValue;
    //        if (textBoxBigBlind.Text.Contains(",") || textBoxBigBlind.Text.Contains("."))
    //        {
    //            MessageBox.Show("The Big Blind can be only round number !");
    //            textBoxBigBlind.Text = bigBlind.ToString();
    //            return;
    //        }
    //        if (!int.TryParse(textBoxSmallBlind.Text, out parsedValue))
    //        {
    //            MessageBox.Show("This is a number only field");
    //            textBoxSmallBlind.Text = bigBlind.ToString();
    //            return;
    //        }
    //        if (int.Parse(textBoxBigBlind.Text) > 200000)
    //        {
    //            MessageBox.Show("The maximum of the Big Blind is 200 000");
    //            textBoxBigBlind.Text = bigBlind.ToString();
    //        }
    //        if (int.Parse(textBoxBigBlind.Text) < 500)
    //        {
    //            MessageBox.Show("The minimum of the Big Blind is 500 $");
    //        }
    //        if (int.Parse(textBoxBigBlind.Text) >= 500 && int.Parse(textBoxBigBlind.Text) <= 200000)
    //        {
    //            bigBlind = int.Parse(textBoxBigBlind.Text);
    //            MessageBox.Show("The changes have been saved ! They will become available the next hand you play. ");
    //        }
    //    }
    //    private void Layout_Change(object sender, LayoutEventArgs e)
    //    {
    //        width = this.Width;
    //        height = this.Height;
    //    }
    //    #endregion
    //}


}