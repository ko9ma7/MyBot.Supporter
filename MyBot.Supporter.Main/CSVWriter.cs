﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyBot.Supporter.Main
{
    public partial class CSVWriter : Form
    {
        static int SelectedLine = -1;
        public CSVWriter()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(SelectedLine == Database.CSVcode.Count - 1)
            {
                Database.CSVcodeAdd("SIDE", numericUpDown5.Value.ToString(), numericUpDown6.Value.ToString(), numericUpDown7.Value.ToString(), numericUpDown8.Value.ToString(), numericUpDown9.Value.ToString(), numericUpDown10.Value.ToString(), numericUpDown11.Value.ToString(), "         ");
                SelectedLine++;
            }
            else
            {
                Database.CSVcodeReplace(SelectedLine, "SIDE", numericUpDown5.Value.ToString(), numericUpDown6.Value.ToString(), numericUpDown7.Value.ToString(), numericUpDown8.Value.ToString(), numericUpDown9.Value.ToString(), numericUpDown10.Value.ToString(), numericUpDown11.Value.ToString(), "         ");
            }
            Database.enabled(groupBox3, false);
            Database.enabled(groupBox4, true);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                File.Create("CSV\\Attack\\" + textBox1.Text + ".csv");
                groupBox5.Enabled = true;
                Database.enabled(button10, false);
                timer1.Interval = 1000;
                timer1.Start();
            }
            else
            {
                if (Database.Language == "English")
                {
                    MessageBox.Show("CSV's name is not completed!");
                }
                else
                {
                    MessageBox.Show("脚本名字未设置！");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "CSV script|*.csv";
            openFile.Title = "!!!";
            string temp = "";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                temp = openFile.FileName.Remove(0, openFile.FileName.LastIndexOf('\\') + 1);
                string name = temp.Remove(temp.Length - 4, 4);
                textBox1.Text = name;
            }
            Database.CSVcode = File.ReadAllLines(openFile.FileName).ToList();
            richTextBox1.Lines = Database.CSVcode.ToArray();
            groupBox5.Enabled = true;
            Database.enabled(button10, false);
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(SelectedLine == Database.CSVcode.Count - 1)
            {
                Database.CSVcodeAdd("      ", "EAGLE      ", "INFERNO    ", "XBOW       ", "WIZTOWER   ", "MORTAR     ", "AIRDEFENSE ", "GEMBOX     ", "GEMBOX     ");
                Database.CSVcodeAdd("SIDEB", numericUpDown18.Value.ToString(), numericUpDown17.Value.ToString(), numericUpDown16.Value.ToString(), numericUpDown15.Value.ToString(), numericUpDown14.Value.ToString(), numericUpDown13.Value.ToString(), " ", " ");
                Database.CSVcodeAdd("      ", "VECTOR_____", "SIDE_______", "DROP_POINTS", "ADDTILES___", "VERSUS_____", "RANDOMX_PX_", "RANDOMY_PX_", "___________");
                Database.enabled(groupBox4, false);
                Database.enabled(groupBox1, true);
                SelectedLine += 3;
            }
            else
            {
                Database.CSVcodeReplace(SelectedLine,"SIDEB", numericUpDown18.Value.ToString(), numericUpDown17.Value.ToString(), numericUpDown16.Value.ToString(), numericUpDown15.Value.ToString(), numericUpDown14.Value.ToString(), numericUpDown13.Value.ToString(), " ", " ");
                Database.enabled(groupBox4, false);
                Database.enabled(groupBox1, true);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(SelectedLine == Database.CSVcode.Count - 1)
            {
                Database.CSVcodeAdd("      ", "VECTOR_____", "SIDE_______", "DROP_POINTS", "ADDTILES___", "VERSUS_____", "RANDOMX_PX_", "RANDOMY_PX_", "___________");
                Database.enabled(groupBox4, false);
                Database.enabled(groupBox1, true);
                SelectedLine++;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string side = "";
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    side = "FRONT-LEFT";
                    break;
                case 1:
                    side = "FRONT-RIGHT";
                    break;
                case 2:
                    side = "LEFT-FRONT";
                    break;
                case 3:
                    side = "RIGHT-FRONT";
                    break;
                case 4:
                    side = "LEFT-BACK";
                    break;
                case 5:
                    side = "RIGHT-BACK";
                    break;
                case 6:
                    side = "BACK-LEFT";
                    break;
                case 7:
                    side = "BACK-RIGHT";
                    break;
                default:
                    if (Database.Language == "English")
                    {
                        MessageBox.Show("Side is not completed!");
                    }
                    else
                    {
                        MessageBox.Show("进攻方向未设置！");
                    }
                    return;
                    break;
            }
            string versus = "";
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    versus = "EXT-INT";
                    break;
                case 1:
                    versus = "INT-EXT";
                    break;
                case 2:
                    versus = "IGNORE";
                    break;
                default:
                    if (Database.Language == "English")
                    {
                        MessageBox.Show("Versus is not completed!");
                    }
                    else
                    {
                        MessageBox.Show("下兵方向未设置！");
                    }
                    return;
                    break;
            }
            string build = "";
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    build = "TOWNHALL";
                    break;
                case 1:
                    build = "EAGLE";
                    break;
                case 2:
                    build = "INFERNO";
                    break;
                case 3:
                    build = "XBOW";
                    break;
                case 4:
                    build = "WIZTOWER";
                    break;
                case 5:
                    build = "MORTAR";
                    break;
                case 6:
                    build = "AIRDEFENSE";
                    break;
            }
            if(SelectedLine == Database.CSVcode.Count - 1)
            {
                Database.CSVcodeAdd("MAKE", textBox2.Text, side, numericUpDown1.Value.ToString(), numericUpDown2.Value.ToString(), versus, numericUpDown3.Value.ToString(), numericUpDown4.Value.ToString(), build);
                Database.alplist.Add(Database.alp.ToString());
                Database.alp++;
                SelectedLine++;
            }
            else
            {
                string[] temp = Database.CSVcode[SelectedLine].Split('|');
                Database.alp = temp[1].ToCharArray()[0];
                Database.CSVcodeReplace(SelectedLine,"MAKE", Database.alp.ToString(), side, numericUpDown1.Value.ToString(), numericUpDown2.Value.ToString(), versus, numericUpDown3.Value.ToString(), numericUpDown4.Value.ToString(), build);
            }
            textBox2.Text = Database.alp.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Database.alp > 'A')
            {
                Database.CSVcodeAdd("      ", "VECTOR_____", "INDEX______", "QTY_X_VECT_", "TROOPNAME__", "DELAY_DROP_", "DELAYCHANGE", "SLEEPAFTER_", "SLEEPBEFORE");
                foreach (var alp in Database.alplist)
                {
                    comboBox5.Items.Add(alp);
                }
                Database.enabled(groupBox1, false);
                Database.enabled(groupBox2, true);
                SelectedLine ++;
            }
            else
            {
                if (Database.Language == "English")
                {
                    MessageBox.Show("You have no MAKE command!");
                }
                else
                {
                    MessageBox.Show("您完全没设置任何下兵点！");
                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && comboBox5.SelectedItem != null)
            {
                string troops = "";
                switch (comboBox4.SelectedIndex)
                {
                    case 0:
                        troops = "Barb";
                        break;
                    case 1:
                        troops = "Arch";
                        break;
                    case 2:
                        troops = "Giant";
                        break;
                    case 3:
                        troops = "Gobl";
                        break;
                    case 4:
                        troops = "Wall";
                        break;
                    case 5:
                        troops = "Ball";
                        break;
                    case 6:
                        troops = "Wiza";
                        break;
                    case 7:
                        troops = "Heal";
                        break;
                    case 8:
                        troops = "Drag";
                        break;
                    case 9:
                        troops = "Pekk";
                        break;
                    case 10:
                        troops = "Babyd";
                        break;
                    case 11:
                        troops = "Mine";
                        break;
                    case 12:
                        troops = "Mini";
                        break;
                    case 13:
                        troops = "Hog";
                        break;
                    case 14:
                        troops = "Valk";
                        break;
                    case 15:
                        troops = "Gole";
                        break;
                    case 16:
                        troops = "Witc";
                        break;
                    case 17:
                        troops = "Lava";
                        break;
                    case 18:
                        troops = "Bowl";
                        break;
                    case 19:
                        troops = "King";
                        break;
                    case 20:
                        troops = "Queen";
                        break;
                    case 21:
                        troops = "Warden";
                        break;
                    case 22:
                        troops = "Castle";
                        break;
                    case 23:
                        troops = "LSpell";
                        break;
                    case 24:
                        troops = "HSpell";
                        break;
                    case 25:
                        troops = "RSpell";
                        break;
                    case 26:
                        troops = "JSpell";
                        break;
                    case 27:
                        troops = "FSpell";
                        break;
                    case 28:
                        troops = "PSpell";
                        break;
                    case 29:
                        troops = "ESpell";
                        break;
                    case 30:
                        troops = "HaSpell";
                        break;
                    case 31:
                        troops = "CSpell";
                        break;
                    case 32:
                        troops = "SkSpell";
                        break;
                    default:
                        if (Database.Language == "English")
                        {
                            MessageBox.Show("Vector is not completed!");
                        }
                        else
                        {
                            MessageBox.Show("下兵位置未设置！");
                        }
                        return;
                        break;
                }
                if (SelectedLine == Database.CSVcode.Count - 1)
                {
                    Database.CSVcodeAdd("DROP ", comboBox5.SelectedItem.ToString(), textBox4.Text, textBox5.Text, troops, textBox6.Text, textBox7.Text, textBox8.Text, "    ");
                    SelectedLine++;
                }
                else
                {
                    Database.CSVcodeReplace(SelectedLine, "DROP ", comboBox5.SelectedItem.ToString(), textBox4.Text, textBox5.Text, troops, textBox6.Text, textBox7.Text, textBox8.Text, "    ");
                }
            }
            else
            {
                if (Database.Language == "English")
                {
                    MessageBox.Show("Please fill up all the info to make DROP Command!");
                }
                else
                {
                    MessageBox.Show("请确保所有空格都被填上以便创建新的下兵代码！");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(Database.CSVcode.Count - 1 == SelectedLine)
            {
                Database.CSVcodeAdd("RECALC", "", "", "", "", "", "", "", "");
                SelectedLine++;
            }
            else
            {
                Database.CSVcodeReplace(SelectedLine,"RECALC", "", "", "", "", "", "", "", "");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Database.WriteAllCode(textBox1.Text);
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            richTextBox1.Lines = Database.CSVcode.ToArray();
            if (SelectedLine > -1 && Database.CSVcode.Count > 0 && SelectedLine < Database.CSVcode.Count)
            {
                textBox3.Text = Database.CSVcode[SelectedLine];
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if(SelectedLine == Database.CSVcode.Count - 1)
            {
                Database.CSVcodeAdd("      ", "EXTR. GOLD", "EXTR.ELIXIR", "EXTR. DARK", "DEPO. GOLD", "DEPO.ELIXIR", "DEPO. DARK", "TOWNHALL", "         ");
                Database.enabled(groupBox5, false);
                Database.enabled(groupBox3, true);
                SelectedLine++;
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox9.Text.Length > 0)
            {
                if (SelectedLine > Database.CSVcode.Count - 1)
                {
                    Database.CSVcode.Add("NOTE |" + textBox9.Text);
                    SelectedLine++;
                }
                else
                {
                    Database.CSVcode[SelectedLine] = Database.CSVcode[SelectedLine] + Environment.NewLine + "NOTE |" + textBox9.Text;
                }

            }
            else
            {
                if (Database.Language == "English")
                {
                    MessageBox.Show("Note is not completed!");
                }
                else
                {
                    MessageBox.Show("解释未设置！");
                }
            }
        }

        private void Language()
        {
            if (Database.Language == "English")
            {
                Text = "CSV Writer";
                label1.Text = "CSV Name";
                button10.Text = "Create New CSV";
                groupBox5.Text = "NOTE";
                button11.Text = "End NOTE";
                button12.Text = "Add NOTE";
                groupBox3.Text = "SIDE";
                label10.Text = "Gold Mine";
                label11.Text = "Elixir Collector";
                label12.Text = "DE Drill";
                label15.Text = "Gold Storage";
                label14.Text = "Elixir Storage";
                label13.Text = "DE Storage";
                label16.Text = "Townhall";
                button5.Text = "End SIDE";
                groupBox4.Text = "SIDEB";
                label23.Text = "Eagle";
                label22.Text = "Inferno";
                label21.Text = "X-Bow";
                label20.Text = "Wizard Tower";
                label19.Text = "Motar";
                label18.Text = "Air Defence";
                button8.Text = "Skip SIDEB";
                button6.Text = "End SIDEB";
                groupBox1.Text = "MAKE";
                label2.Text = "Vector";
                label3.Text = "Side";
                label4.Text = "Drop Points";
                label5.Text = "Add tiles";
                label6.Text = "Versus";
                label7.Text = "Random X";
                label8.Text = "Random Y";
                label9.Text = "Special buildings";
                button4.Text = "End MAKE";
                button3.Text = "Add MAKE";
                groupBox2.Text = "DROP";
                label17.Text = "Vector";
                label24.Text = "Index";
                label25.Text = "Quantity";
                label26.Text = "Troops";
                label27.Text = "Delay Drops";
                label28.Text = "Delay Change";
                label29.Text = "Sleep After";
                button1.Text = "Add DROP";
                button7.Text = "Add Recalculate";
                button9.Text = "End CSV";
                button13.Text = "Delete Line";
            }
            else
            {
                Text = "CSV 编写器";
                label1.Text = "CSV 名字";
                button10.Text = "创建新CSV";
                groupBox5.Text = "注释";
                button11.Text = "结束注释";
                button12.Text = "增加注释";
                groupBox3.Text = "下兵边判断";
                label10.Text = "金矿";
                label11.Text = "圣水采集器";
                label12.Text = "暗黑油井";
                label15.Text = "金库";
                label14.Text = "圣水罐";
                label13.Text = "黑油罐";
                label16.Text = "大本营";
                button5.Text = "结束下兵边判断";
                groupBox4.Text = "下兵边判断B";
                label23.Text = "天鹰";
                label22.Text = "地狱塔";
                label21.Text = "X-弩";
                label20.Text = "法师塔";
                label19.Text = "迫击炮";
                label18.Text = "防空";
                button8.Text = "跳过下兵边判断B";
                button6.Text = "结束下兵边判断B";
                groupBox1.Text = "制造下兵点";
                label2.Text = "下兵点名称";
                label3.Text = "方向";
                label4.Text = "下兵点";
                label5.Text = "距离红线";
                label6.Text = "下兵时滑动方向";
                label7.Text = "随机 X";
                label8.Text = "随机 Y";
                label9.Text = "特殊建筑物";
                button4.Text = "结束制造下兵点";
                button3.Text = "增加制造下兵点";
                groupBox2.Text = "下兵";
                label17.Text = "下兵点名称";
                label24.Text = "下兵点数值";
                label25.Text = "下兵数量";
                label26.Text = "兵";
                label27.Text = "下兵延时";
                label28.Text = "增加随机下兵延时";
                label29.Text = "下完兵后延时";
                button1.Text = "增加下兵";
                button7.Text = "增加重新计算剩余兵力";
                button9.Text = "结束CSV";
                button13.Text = "删除最新行";
                comboBox1.Items.Clear();
                comboBox1.Items.Add("主要边的左半部");
                comboBox1.Items.Add("主要边的右半部");
                comboBox1.Items.Add("接近主要边的左边方向");
                comboBox1.Items.Add("接近主要边的右边方向");
                comboBox1.Items.Add("远离主要边的左边方向");
                comboBox1.Items.Add("远离主要边的右边方向");
                comboBox1.Items.Add("远离主要边的左半部");
                comboBox1.Items.Add("远离主要边的右半部");
                comboBox2.Items.Clear();
                comboBox2.Items.Add("从外向里");
                comboBox2.Items.Add("从里向外");
                comboBox2.Items.Add("丢在建筑物上");
                comboBox3.Items.Clear();
                comboBox3.Items.Add("大本营");
                comboBox3.Items.Add("天鹰火炮");
                comboBox3.Items.Add("地狱塔");
                comboBox3.Items.Add("X-弩");
                comboBox3.Items.Add("法师塔");
                comboBox3.Items.Add("迫击炮");
                comboBox3.Items.Add("防空");
                comboBox4.Items.Clear();
                comboBox4.Items.Add("野蛮人");
                comboBox4.Items.Add("弓箭手");
                comboBox4.Items.Add("巨人");
                comboBox4.Items.Add("哥布林");
                comboBox4.Items.Add("炸弹人");
                comboBox4.Items.Add("气球兵");
                comboBox4.Items.Add("法师");
                comboBox4.Items.Add("天使");
                comboBox4.Items.Add("龙");
                comboBox4.Items.Add("皮卡超人");
                comboBox4.Items.Add("飞龙宝宝");
                comboBox4.Items.Add("矿工");
                comboBox4.Items.Add("亡灵");
                comboBox4.Items.Add("野猪骑士");
                comboBox4.Items.Add("武神");
                comboBox4.Items.Add("戈伦石人");
                comboBox4.Items.Add("女巫");
                comboBox4.Items.Add("熔岩猎犬");
                comboBox4.Items.Add("巨石投手");
                comboBox4.Items.Add("蛮王（或开技能）");
                comboBox4.Items.Add("女王（或开技能）");
                comboBox4.Items.Add("守护（或开技能）");
                comboBox4.Items.Add("部落城堡援军");
                comboBox4.Items.Add("闪电法术");
                comboBox4.Items.Add("治疗法术");
                comboBox4.Items.Add("狂暴法术");
                comboBox4.Items.Add("弹跳法术");
                comboBox4.Items.Add("冰冻法术");
                comboBox4.Items.Add("毒药法术");
                comboBox4.Items.Add("地震药水");
                comboBox4.Items.Add("极速药水");
                comboBox4.Items.Add("镜像法术");
                comboBox4.Items.Add("骷髅法术");
            }
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            string shows = "";
            if (Database.Language == "English")
            {
                shows = Database.ENTips("Gold Mine");
            }
            else
            {
                shows = Database.CNTips("金矿");
            }
            toolTip1.Show(shows, label10);
            Task.Delay(5000);
            toolTip1.Hide(label10);
        }

        private void label11_MouseHover(object sender, EventArgs e)
        {
            string shows = "";
            if (Database.Language == "English")
            {
                shows = Database.ENTips("Elixir Collector");
            }
            else
            {
                shows = Database.CNTips("圣水采集器");
            }
            toolTip1.Show(shows, label11);
            Task.Delay(5000);
            toolTip1.Hide(label11);
        }

        private void label12_MouseHover(object sender, EventArgs e)
        {
            string shows = "";
            if (Database.Language == "English")
            {
                shows = Database.ENTips("DE Drill");
            }
            else
            {
                shows = Database.CNTips("暗黑油井");
            }
            toolTip1.Show(shows, label12);
            Task.Delay(5000);
            toolTip1.Hide(label12);
        }

        private void label15_MouseHover(object sender, EventArgs e)
        {
            string shows = "";
            if (Database.Language == "English")
            {
                shows = Database.ENTips("Gold Storage");
            }
            else
            {
                shows = Database.CNTips("金库");
            }
            toolTip1.Show(shows, label15);
            Task.Delay(5000);
            toolTip1.Hide(label15);
        }

        private void label14_MouseHover(object sender, EventArgs e)
        {
            string shows = "";
            if (Database.Language == "English")
            {
                shows = Database.ENTips("Elixir Storage");
            }
            else
            {
                shows = Database.CNTips("圣水库");
            }
            toolTip1.Show(shows, label14);
            Task.Delay(5000);
            toolTip1.Hide(label14);
        }

        private void label13_MouseHover(object sender, EventArgs e)
        {
            string shows = "";
            if (Database.Language == "English")
            {
                shows = Database.ENTips("DE Storage");
            }
            else
            {
                shows = Database.CNTips("黑油罐");
            }
            toolTip1.Show(shows, label13);
            Task.Delay(5000);
            toolTip1.Hide(label13);
        }

        private void label16_MouseHover(object sender, EventArgs e)
        {
            string shows = "";
            if (Database.Language == "English")
            {
                shows = Database.ENTips("Townhall");
            }
            else
            {
                shows = Database.CNTips("大本营");
            }
            toolTip1.Show(shows, label16);
            Task.Delay(5000);
            toolTip1.Hide(label16);
        }

        private void label23_MouseHover(object sender, EventArgs e)
        {
            string shows = "";
            if (Database.Language == "English")
            {
                shows = Database.ENTips("Eagle");
            }
            else
            {
                shows = Database.CNTips("天鹰");
            }
            toolTip1.Show(shows, label23);
            Task.Delay(5000);
            toolTip1.Hide(label23);
        }

        private void label22_MouseHover(object sender, EventArgs e)
        {
            string shows = "";
            if (Database.Language == "English")
            {
                shows = Database.ENTips("Inferno");
            }
            else
            {
                shows = Database.CNTips("地狱塔");
            }
            toolTip1.Show(shows, label22);
            Task.Delay(5000);
            toolTip1.Hide(label22);
        }

        private void label21_MouseHover(object sender, EventArgs e)
        {
            string shows = "";
            if (Database.Language == "English")
            {
                shows = Database.ENTips("X-Bow");
            }
            else
            {
                shows = Database.CNTips("X-弩");
            }
            toolTip1.Show(shows, label21);
            Task.Delay(5000);
            toolTip1.Hide(label21);
        }

        private void label20_MouseHover(object sender, EventArgs e)
        {
            string shows = "";
            if (Database.Language == "English")
            {
                shows = Database.ENTips("Wizard Tower");
            }
            else
            {
                shows = Database.CNTips("法师塔");
            }
            toolTip1.Show(shows, label20);
            Task.Delay(5000);
            toolTip1.Hide(label20);
        }

        private void label19_MouseHover(object sender, EventArgs e)
        {
            string shows = "";
            if (Database.Language == "English")
            {
                shows = Database.ENTips("Motar");
            }
            else
            {
                shows = Database.CNTips("迫击炮");
            }
            toolTip1.Show(shows, label19);
            Task.Delay(5000);
            toolTip1.Hide(label19);
        }

        private void label18_MouseHover(object sender, EventArgs e)
        {
            string shows = "";
            if (Database.Language == "English")
            {
                shows = Database.ENTips("Air Defence");
            }
            else
            {
                shows = Database.CNTips("防空火箭");
            }
            toolTip1.Show(shows, label18);
            Task.Delay(5000);
            toolTip1.Hide(label18);
        }
        private void button13_Click(object sender, EventArgs e)
        {
            if (Database.CSVcode.Count > 0)
            {
                if(SelectedLine == Database.CSVcode.Count-1)
                {
                    if (Database.CSVcode[Database.CSVcode.Count - 1].Split('|').Contains("INDEX______"))
                    {
                        groupBox1.Enabled = true;
                        groupBox2.Enabled = false;
                    }
                    else if (Database.CSVcode[Database.CSVcode.Count - 1].Split('|').Contains("SIDE_______"))
                    {
                        Database.alp = 'A';
                        Database.alplist.Clear();
                        textBox2.Text = Database.alp.ToString();
                        foreach (var i in comboBox5.Items)
                        {
                            if (i != null)
                            {
                                comboBox5.Items.Remove(i);
                            }
                        }
                        groupBox1.Enabled = false;
                        groupBox3.Enabled = true;
                    }
                    else if (Database.CSVcode[Database.CSVcode.Count - 1].Split('|').Contains("EXTR.ELIXIR"))
                    {
                        groupBox3.Enabled = false;
                        groupBox5.Enabled = true;
                    }
                    Database.CSVcode.RemoveAt(Database.CSVcode.Count - 1);
                    SelectedLine--;
                }
                else
                {
                    if (Database.CSVcode[SelectedLine].Split('|').Contains("INDEX______"))
                    {
                        groupBox1.Enabled = true;
                        groupBox2.Enabled = false;
                    }
                    else if (Database.CSVcode[SelectedLine].Split('|').Contains("SIDE_______"))
                    {
                        Database.alp = 'A';
                        Database.alplist.Clear();
                        textBox2.Text = Database.alp.ToString();
                        foreach (var i in comboBox5.Items)
                        {
                            if (i != null)
                            {
                                comboBox5.Items.Remove(i);
                            }
                        }
                        groupBox1.Enabled = false;
                        groupBox3.Enabled = true;
                    }
                    else if (Database.CSVcode[SelectedLine].Split('|').Contains("EXTR.ELIXIR"))
                    {
                        groupBox3.Enabled = false;
                        groupBox5.Enabled = true;
                    }
                    Database.CSVcode.RemoveAt(SelectedLine + 1);
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex != null)
            {
                comboBox2.SelectedIndex = 2;
            }
        }

        private void CSVWriter_Load(object sender, EventArgs e)
        {
            Language();
            Database.loadingprocess = 100;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Database.OnlyNum(e,toolTip1,textBox4);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Database.OnlyNum(e, toolTip1, textBox5);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            Database.OnlyNum(e, toolTip1, textBox6);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            Database.OnlyNum(e, toolTip1, textBox7);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            Database.OnlyNum(e, toolTip1, textBox8);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (Database.CSVcode.Count > 0)
            {
                if (Database.CSVcode[SelectedLine].Split('|').Contains("INDEX______"))
                {
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = false;
                }
                else if (Database.CSVcode[SelectedLine].Split('|').Contains("SIDE_______"))
                {
                    Database.alp = 'A';
                    Database.alplist.Clear();
                    textBox2.Text = Database.alp.ToString();
                    foreach (var i in comboBox5.Items)
                    {
                        if (i != null)
                        {
                            comboBox5.Items.Remove(i);
                        }
                    }
                    groupBox1.Enabled = false;
                    groupBox3.Enabled = true;
                }
                else if (Database.CSVcode[SelectedLine].Split('|').Contains("EXTR.ELIXIR"))
                {
                    groupBox3.Enabled = false;
                    groupBox5.Enabled = true;
                }
                SelectedLine--;
            }

        }


        private void button15_Click(object sender, EventArgs e)
        {

            if (SelectedLine < Database.CSVcode.Count)
            {
                SelectedLine++;
                if (Database.CSVcode[SelectedLine].Split('|').Contains("INDEX______"))
                {
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = true;
                }
                else if (Database.CSVcode[SelectedLine].Split('|').Contains("SIDE_______"))
                {
                    Database.alp = 'A';
                    Database.alplist.Clear();
                    textBox2.Text = Database.alp.ToString();
                    foreach (var i in comboBox5.Items)
                    {
                        if (i != null)
                        {
                            comboBox5.Items.Remove(i);
                        }
                    }
                    groupBox1.Enabled = true;
                    groupBox3.Enabled = false;
                }
                else if (Database.CSVcode[SelectedLine].Split('|').Contains("EXTR.ELIXIR"))
                {
                    groupBox3.Enabled = true;
                    groupBox5.Enabled = false;
                }
            }
        }
    }
}