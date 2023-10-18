#include "Ai.h"

void Ai::init(Chess* chess)
{
	this->chess = chess;

	int size = chess->getGradeSize();

	for (int i = 0; i < size; i += 1) {
		vector<int> row;
		for (int j = 0; j < size; j += 1) {
			row.push_back(0);
		}

		scoreMap.push_back(row);
	}
}

void Ai::go()
{
	ChessPos pos = think();
	Sleep(1000);
	chess->chessDown(&pos, CHESS_WHITE);

}

void Ai::calculateScore()
{

	int personNum = 0; // how many continue chess for player
	int aiNum = 0; // how many comtinue for ai
	int emptyNum = 0; //how many blank


	//calculate the score, clear the array first
	for (int i = 0; i < scoreMap.size(); i += 1) {
		for (int j = 0; j < scoreMap[i].size(); j += 1) {
			scoreMap[i][j] = 0;
		}
	}

	int size = chess->getGradeSize();
	for (int row = 0; row < size; row += 1) {
		for (int col = 0; col < size; col += 1) {
			
			/*
			personNum = 0; // how many continue chess for player
			aiNum = 0; // how many comtinue for ai
			emptyNum = 0; //how many blank
			*/

			//calculate the score for every point
			if (chess->getChessData(row, col)) continue;

			for (int y = -1; y <= 0; y += 1) {
				for (int x = -1; x <= 1; x += 1) {

					if (y == 0 && x == 0) continue;
					if (y == 0 && x != 1) continue;

					personNum = 0; // how many continue chess for player
					aiNum = 0; // how many comtinue for ai
					emptyNum = 0; //how many blank

					//assum black chess move, what consiquence
					for (int i = 1; i <= 4; i += 1) {
						int curRow = row + i * y;
						int curCol = col + i * x;

						if (curRow >= 0 && curRow < size && curCol >= 0 && curCol < size && chess->getChessData(curRow, curCol) == 1) {
							personNum += 1;
						}
						else if (curRow >= 0 && curRow < size && curCol >= 0 && curCol < size && chess->getChessData(curRow, curCol) == 0) {
							emptyNum += 1;
							break;
						}
						else {
							break;
						}
					}

					
					//check reverse // maybe unnessesary
					for (int i = 1; i <= 4; i += 1) {
						int curRow = row - i * y;
						int curCol = col - i * x;

						if (curRow >= 0 && curRow < size && curCol >= 0 && curCol < size && chess->getChessData(curRow, curCol) == 1) {
							personNum += 1;
						}
						else if (curRow >= 0 && curRow < size && curCol >= 0 && curCol < size && chess->getChessData(curRow, curCol) == 0) {
							emptyNum += 1;
							break;
						}
						else {
							break;
						}

					}
					

					if (personNum == 1) { // 2 con.
						scoreMap[row][col] += 10;
					}
					else if (personNum == 2) {
						if (emptyNum == 1) {
							scoreMap[row][col] += 30;
						}
						else if (emptyNum == 2) {
							scoreMap[row][col] += 40;
						}
					}
					else if (personNum == 3) {
						if (emptyNum == 1) {
							scoreMap[row][col] += 60;
						}
						else if (emptyNum == 2) {
							scoreMap[row][col] += 200;
						}
					}
					else if (personNum == 4) {
						scoreMap[row][col] += 20000;
					}

					emptyNum = 0;

					//rate for white
					for (int i = 1; i <= 4; i += 1) {
						int curRow = row + i * y;
						int curCol = col + i * x;

						if (curRow >= 0 && curRow < size && curCol >= 0 && curCol < size && chess->getChessData(curRow, curCol) == -1) {
							aiNum += 1;
						}
						else if (curRow >= 0 && curRow < size && curCol >= 0 && curCol < size && chess->getChessData(curRow, curCol) == 0) {
							emptyNum += 1;
							break;
						}
						else {
							break;
						}
					}

					//reverse
					for (int i = 1; i <= 4; i += 1) {
						int curRow = row - i * y;
						int curCol = col - i * x;

						if (curRow >= 0 && curRow < size && curCol >= 0 && curCol < size && chess->getChessData(curRow, curCol) == -1) {
							aiNum += 1;
						}
						else if (curRow >= 0 && curRow < size && curCol >= 0 && curCol < size && chess->getChessData(curRow, curCol) == 0) {
							emptyNum += 1;
							break;
						}
						else {
							break;
						}
					}
					
					if (aiNum == 0) {
						scoreMap[row][col] += 5;
					}
					else if (aiNum == 1) {
						scoreMap[row][col] += 10;
					}
					else if (aiNum == 2) {
						if (emptyNum == 1) {
							scoreMap[row][col] += 25;
						}
						else if (emptyNum == 2) {
							scoreMap[row][col] += 50;
						}
					}
					else if (aiNum == 3) {
						if (emptyNum == 1) {
							scoreMap[row][col] += 55;
						}
						else if (emptyNum == 2) {
							scoreMap[row][col] += 10000;
						}
					}
					else if (aiNum >= 4) {
						scoreMap[row][col] += 30000;
					}


				}
			}
		}
	}
}

ChessPos Ai::think()
{
	calculateScore();

	vector<ChessPos> maxPoints;
	int maxScore = 0;
	int size = chess->getGradeSize();
	for (int row = 0; row < size; row += 1) {
		for (int col = 0; col < size; col += 1) {
			if (chess->getChessData(row, col) == 0) {
				if (scoreMap[row][col] > maxScore) {
					maxScore = scoreMap[row][col];
					maxPoints.clear();
					maxPoints.push_back(ChessPos(row, col));
				}
				else if (scoreMap[row][col] == maxScore) {
					maxPoints.push_back(ChessPos(row, col));
				}
			}
		}
	}

	int index = rand() % maxPoints.size();
	return maxPoints[index];
}
