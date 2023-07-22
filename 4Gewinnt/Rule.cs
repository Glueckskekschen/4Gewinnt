using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Gewinnt
{
    internal static class Rule
    {
        //flase = 
        public static bool turn = false;
        public static bool gameOver = false;
        public static List<PictureBoxTemplate> cell = new List<PictureBoxTemplate>();

        static Rule()
        {
            /*
              0  1  2  3  4  5  6
              7  8  9 10 11 12 13
             14 15 16 17 18 19 20
             21	22 23 24 25 26 27
             28	29 30 31 32 33 34
             35 36 37 38 39 40 41
             */
            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    PictureBoxTemplate temp = new PictureBoxTemplate((y*7)+x,x * 100, y * 100, 100, 100);
                    cell.Add(temp);
                }
            }
        }

        private static bool CheckDiagonal()
        {
            foreach (PictureBoxTemplate item in cell)
            {
                int iYellow = 0;
                int iRed = 0;
                int[] iarray = {4,5,6,11,12,13,18,19,20,25,26,27,32,33,34,39,40,41};
                if (iarray.Contains(item.index))
                {
                    continue;
                }
                if ((item.owner != '0'))
                {
                    var temp = (item.owner == '1') ? iYellow++ : iRed++;
                    char cSearch;
                    temp = (iYellow != 0) ? cSearch = '1' : cSearch = '2';
                    if ((item.index + 8 < 42) && cell[item.index + 8].owner == cSearch)
                    {
                        temp = (cell[item.index + 8].owner == '1') ? iYellow++ : iRed++;
                        if ((item.index + 16 < 42) && cell[item.index + 16].owner == cSearch)
                        {
                            temp = (cell[item.index + 16].owner == '1') ? iYellow++ : iRed++;
                            if ((item.index + 24 < 42) && cell[item.index + 24].owner == cSearch)
                            {
                                temp = (cell[item.index + 24].owner == '1') ? iYellow++ : iRed++;
                                if ((item.index + 32 < 42) && cell[item.index + 32].owner == cSearch)
                                {
                                    temp = (cell[item.index + 32].owner == '1') ? iYellow++ : iRed++;
                                }
                            }
                        }
                    }
                }
                if(iYellow >= 4 || iRed >= 4)
                {
                    System.Windows.Forms.MessageBox.Show("Game Over\n Dia ->");
                }
            }

            foreach (PictureBoxTemplate item in cell)
            {
                int iYellow = 0;
                int iRed = 0;
                int[] iarray = { 0, 1, 2, 7, 8, 9, 14, 15, 16, 21, 22, 23, 28, 29, 30, 35, 36, 37 };
                if (iarray.Contains(item.index))
                {
                    continue;
                }
                if ((item.owner != '0'))
                {
                    var temp = (item.owner == '1') ? iYellow++ : iRed++;
                    char cSearch;
                    temp = (iYellow != 0) ? cSearch = '1' : cSearch = '2';
                    if ((item.index + 6 < 42) && cell[item.index + 6].owner == cSearch)
                    {
                        temp = (cell[item.index + 6].owner == '1') ? iYellow++ : iRed++;
                        if ((item.index + 12 < 42) && cell[item.index + 12].owner == cSearch)
                        {
                            temp = (cell[item.index + 12].owner == '1') ? iYellow++ : iRed++;
                            if ((item.index + 18 < 42) && cell[item.index + 18].owner == cSearch)
                            {
                                temp = (cell[item.index + 18].owner == '1') ? iYellow++ : iRed++;
                                if ((item.index + 24 < 42) && cell[item.index + 24].owner == cSearch)
                                {
                                    temp = (cell[item.index + 24].owner == '1') ? iYellow++ : iRed++;
                                }
                            }
                        }
                    }
                }
                if (iYellow >= 4 || iRed >= 4)
                {
                    System.Windows.Forms.MessageBox.Show("Game Over\n Dia <-");
                }
            }

            return false;
        }

        private static bool CheckWinY()
        {
            for (int x = 0; x < 7; x++)
            {
                int iYellowY = 0;
                int iRedY = 0;
                for (int y = 0; y < 6; y++)
                {
                    if (cell[(y * 7) + x].owner == '1')
                    {
                        iYellowY++;
                        iRedY = 0;
                    }
                    else if (cell[(y * 7) + x].owner == '2')
                    {
                        iRedY++;
                        iYellowY = 0;
                    }
                    else
                    {
                        iYellowY = 0;
                        iRedY = 0;
                    }
                    if (iYellowY >= 4 || iRedY >= 4)
                    {
                        gameOver = true;
                        System.Windows.Forms.MessageBox.Show("Game Over\nY");
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool CheckWinX()
        {
            for (int y = 0; y < 6; y++)
            {
                int iYellowX = 0;
                int iRedX = 0;
                for (int x = 0; x < 7; x++)
                {
                    if (cell[(y * 7) + x].owner == '1')
                    {
                        iYellowX++;
                        iRedX = 0;
                    }
                    else if (cell[(y * 7) + x].owner == '2')
                    {
                        iRedX++;
                        iYellowX = 0;
                    }
                    else
                    {
                        iYellowX = 0;
                        iRedX = 0;
                    }
                    if (iYellowX >= 4 || iRedX >= 4)
                    {
                        gameOver = true;
                        System.Windows.Forms.MessageBox.Show("Game Over\nX");
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool isGameOver()
        {
            if (CheckWinX() || CheckWinY() || CheckDiagonal())
            {
                return true;
            }

            return false;
        }

        private static void setTurn(int index)
        {
            cell[index].isSet = true;
            if (turn)
            {
                cell[index].owner = '1';
                cell[index].MakeYellow();
                turn = false;
            }
            else
            {
                cell[index].owner = '2';
                cell[index].MakeRed();
                turn = true;
            }
            isGameOver();
        }

        public static bool isTurnValid(int index)
        {
            if (gameOver)
            {
                return false;
            }
            if (index<0 && index>41)
            {
                return false;
            }
            if(cell[index].isSet)
            {
                return false;
            }
            //Last Row
            if (index>=35)
            {
                setTurn(index);
                return true;
            }
            //Check Row under
            if(cell[index+7].isSet)
            {
                setTurn(index);
                return true;
            }
           
            return false;
            
        }

        
    }
}
