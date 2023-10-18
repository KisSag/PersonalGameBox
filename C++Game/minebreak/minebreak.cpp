// minebreak.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <easyx.h>

#define ROW 10
#define COL 10
#define IMGW 35
#define BOMBNUM 10

void initialMap(int map[ROW][COL]) {

	//create blank map
	for (int i = 0; i < ROW; i += 1) {
		for (int j = 0; j < COL; j += 1) {
			printf("%2d", map[i][j]);
		}
		printf("\n");
	}
	printf("\n");

}

void setNum(int map[ROW][COL], int i, int j) {
	for (int k = i - 1; k <= i + 1; k += 1) {
		for (int g = j - 1; g <= j + 1; g += 1) {
			if (map[k][g] != -1 && k > -1 && k < ROW && g > -1 && g < COL) {
				map[k][g] += 1;
			}
		}
	}

	
	
}

void setBomb(int map[ROW][COL]) {
	for (int i = 0; i < BOMBNUM; i += 1) {
		int row = rand() % 10;
		int col = rand() % 10;

		//check duplicate
		if (map[row][col] == -1) {
			i -= 1;
		}
		else {
			map[row][col] = -1;
		}

	}
}

void drawMap(int map[ROW][COL], IMAGE img[]) {
	for (int i = 0; i < ROW; i += 1) {
		for (int j = 0; j < COL; j += 1) {
			if (map[i][j] >= 0 && map[i][j] <= 8) {
				putimage(j * IMGW, i * IMGW, img + map[i][j]);
			}
			else if (map[i][j] == -1) {
				putimage(j * IMGW, i * IMGW, img + 11);
			}
			else if (map[i][j] >= 19 && map[i][j] <= 28) {
				putimage(j * IMGW, i * IMGW, img + 9);
			}
			else if (map[i][j] >= 39 && map[i][j] <= 48) {
				putimage(j * IMGW, i * IMGW, img + 10);
			}
		}
	}
}

void loadInterface(int map[ROW][COL], IMAGE img[]) {
	
	for (int i = 0; i < 12; i += 1) {
		char fileName[50] = { 0 };
		sprintf_s(fileName, "./images/%d.jpg", i);
		loadimage(img + i, fileName, IMGW, IMGW);
		//putimage(IMGW * i, 0, img + i); // this is a image test
	}

	for (int i = 0; i < ROW; i += 1) {
		for (int j = 0; j < COL; j += 1) {
			if (map[i][j] >= 0 && map[i][j] <= 8) {
				putimage(j * IMGW, i * IMGW, img + map[i][j]);
			}
			else if (map[i][j] == -1) {
				putimage(j * IMGW, i * IMGW, img + 11);
			}
			else if (map[i][j] >= 19 && map[i][j] <= 28) {
				putimage(j * IMGW, i * IMGW, img + 9);
			}
		}
	}

	
	
}

void cover(int map[ROW][COL]) {
	for (int i = 0; i < ROW; i += 1) {
		for (int j = 0; j < COL; j += 1) {
			map[i][j] += 20;
		}
	}
}

void bloom(int map[ROW][COL], int r, int c) {
	//judge if blank
	if (map[r][c] == 0) {
		for (int k = r - 1; k <= r + 1; k += 1) {
			for (int g = c - 1; g <= c + 1; g += 1) {
				if (map[k][g] != -1 && k > -1 && k < ROW && g > -1 && g < COL) {
					if (map[k][g] >= 20 && map[k][g] <= 28) {
						map[k][g] -= 20;
						bloom(map, k, g);
					}
				}
			}
		}
	}
}

void endMsg(int ret) {
	if (ret == -1) {
		int select = MessageBox(GetHWnd(), "Sorry, you lose", "Mine Eplode", MB_OKCANCEL);
		if (select == IDOK) { // other round
			exit(0);
		}
		else {
			exit(0);
		}
	}
	else if(ret == 1) {
		int select = MessageBox(GetHWnd(), "Congrates, you win", "all Mine Founded", MB_OKCANCEL);
		if (select == IDOK) { // other round
			exit(0);
		}
		else {
			exit(0);
		}
	}
}

int gameEnd(int map[ROW][COL], int r, int c) {
	//mine explode, lose
	if (map[r][c] == -1 || map[r][c] == 19) {
		return -1;
	}

	//all block clicked, win
	int count = 0;
	for (int i = 0; i < ROW; i += 1) {
		for (int j = 0; j < COL; j += 1) {
			if (map[i][j] >= 0 && map[i][j] <= 8) {
				count += 1;
			}
		}
	}

	if (count == ROW * COL - BOMBNUM) {
		return 1;
	}
}

void mouseEvent(int map[ROW][COL]) {
	//define message framework
	ExMessage msg;
	if (peekmessage(&msg, EX_MOUSE)) {

		//change mouse location to array location

		int c = msg.x / IMGW;
		int r = msg.y / IMGW;
		int ret = 0;

		if (msg.message == WM_LBUTTONDOWN) { // left down
			if (map[r][c] > 18 && map[r][c] < 29) {
				map[r][c] -= 20;
				bloom(map, r, c);
			}
			ret = gameEnd(map, r, c); //judge if game end
			//initialMap(map); // test
		}
		else if (msg.message == WM_RBUTTONDOWN) { //right down
			if (map[r][c] > 18 && map[r][c] < 29) {
				map[r][c] += 20;
			}else if (map[r][c] > 38) {
				map[r][c] -= 20;
			}
			ret = gameEnd(map, r, c); //judge if game end
			//initialMap(map);
		}

		endMsg(ret); //judge if game end

	}

}


int main()
{	
	initgraph(COL * IMGW, ROW * IMGW, EX_SHOWCONSOLE);

	//set ramdom
	srand((unsigned)time(NULL));

	//define map
	int map[ROW][COL] = { 0 };

	//set bomb(= -1)
	setBomb(map);

	for (int i = 0; i < ROW; i += 1) {
		for (int j = 0; j < COL; j += 1) 
		{
			if (map[i][j] == -1) {
				setNum(map, i, j);
			}

		}
		printf("\n");
	}
	
	cover(map);


	//interface
	IMAGE img[12];
	loadInterface(map, img);

	while (true) {
		mouseEvent(map);
		drawMap(map, img);
	}
	

	
	initialMap(map);

	getchar();

	return 0;
}
