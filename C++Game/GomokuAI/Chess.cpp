#include "Chess.h"
#include<graphics.h>
#include<math.h>
#include<conio.h>

/*
void putimagePNG(int x, int y, IMAGE* pic) {
	DWORD* dst = GetImageBuffer();
	DWORD* draw = GetImageBuffer();
	DWORD* src = GetImageBuffer();
	int pic_w = pic->getwidth();
	int pic_h = pic->getheight();
	int gra_w = getwidth();
	int gra_h = getheight();
	int dstX = 0;

	for (int iy = 0; iy < pic_h; iy += 1) {
		for (int ix = 0; ix < pic_w; ix += 1) {
			int srcX = ix + iy * pic_w;
			int sa = ((src[srcX] & 0xff000000) >> 24);
			int sr = ((src[srcX] & 0xff0000) >> 16);
			int sg = ((src[srcX] & 0xff00) >> 8);
			int sb = src[srcX] & 0xff;
			if (ix >= 0 && ix <= gra_w && iy >= 0 && iy <= gra_h && dstX <= gra_w * gra_w) {
				dstX = (ix + x) + (iy + y) * gra_w;
				int dr = ((dst[dstX] & 0xff0000) >> 16);
				int dg = ((dst[dstX] & 0xff00) >> 8);
				int db = dst[dstX] & 0xff;
				draw[dstX] = ((sr * sa / 255 + dr * (255 - sa) / 255) << 16) | ((sg * sa / 255 + dg * (255 - sa) / 255) << 8) | (sb * sa / 255 + db * (255 - sa) / 255);
			}
		}
	}
}
*/


Chess::Chess(int gradeSize, int marginX, int marginY, float chessSize)
{
	this->gradeSize = gradeSize;
	this->margin_x = marginX;
	this->margin_y = marginY;
	this->chessSize = chessSize;
	playerFlag = CHESS_BLACK;

	for (int i = 0; i < gradeSize; i += 1) {
		vector<int> row;
		for (int j = 0; j < gradeSize; j += 1) {
			row.push_back(0);
		}
		chessMap.push_back(row);
	}

}

void Chess::init()
{
	//create windows
	initgraph(558, 558, EW_SHOWCONSOLE);

	//show the chess board
	loadimage(0, "images/board.jpg");

	//load chess img
	loadimage(&chessBlackImg, "images/black.jpg", chessSize, chessSize, true);
	loadimage(&chessWhiteImg, "images/white.jpg", chessSize, chessSize, true);

	//clean the chessboard
	for (int i = 0; i < chessMap.size(); i += 1) {
		for (int j = 0; j < chessMap.size(); j += 1) {
			chessMap[i][j] = 0;
		}
	}

	playerFlag = true;

}

bool Chess::clickBoard(int x, int y, ChessPos* pos)
{
	int col = (x - margin_x) / chessSize;
	int row = (y - margin_y) / chessSize;
	int leftTopPosX = margin_x + chessSize * col;
	int leftTopPosY = margin_y + chessSize * row;
	int offset = chessSize * 0.4;

	int len;
	bool ret = false;

	do {

		//check the left top
		len = sqrt((x - leftTopPosX) * (x - leftTopPosX) + (y - leftTopPosY) * (y - leftTopPosY));

		if (len < offset) {
			pos->row = row;
			pos->col = col;
			if (chessMap[pos->row][pos->col] == 0) {
				ret = true;
			}

			break;
		}

		//check the right top
		int x2 = leftTopPosX + chessSize;
		int y2 = leftTopPosY;
		len = sqrt((x - x2) * (x - x2) + (y - y2) * (y - y2));

		if (len < offset) {
			pos->row = row;
			pos->col = col + 1;
			if (chessMap[pos->row][pos->col] == 0) {
				ret = true;
			}

			break;
		}

		//check the left down
		x2 = leftTopPosX;
		y2 = leftTopPosY + chessSize;
		len = sqrt((x - x2) * (x - x2) + (y - y2) * (y - y2));

		if (len < offset) {
			pos->row = row + 1;
			pos->col = col;
			if (chessMap[pos->row][pos->col] == 0) {
				ret = true;
			}

			break;
		}

		//check the right down
		x2 = leftTopPosX + chessSize;
		y2 = leftTopPosY + chessSize;
		len = sqrt((x - x2) * (x - x2) + (y - y2) * (y - y2));

		if (len < offset) {
			pos->row = row + 1;
			pos->col = col + 1;
			if (chessMap[pos->row][pos->col] == 0) {
				ret = true;
			}

			break;
		}

	} while (0);
	
	return ret;
}

void Chess::chessDown(ChessPos* pos, chess_kind_t kind)
{
	int x = margin_x + chessSize * pos->col - 0.5 * chessSize;
	int y = margin_y + chessSize * pos->row - 0.5 * chessSize;

	if (kind == CHESS_WHITE) {
		putimage(x, y, &chessWhiteImg);
	}
	else {
		putimage(x, y, &chessBlackImg);
	}

	updateGameMap(pos);
}

int Chess::getGradeSize()
{
	return gradeSize;
}

int Chess::getChessData(ChessPos* pos)
{
	return chessMap[pos->row][pos->col];
}

int Chess::getChessData(int row, int col)
{
	return chessMap[row][col];
}

bool Chess::checkOver()
{
	//check win
	if (checkWin()) {

		Sleep(1500);

		if (playerFlag == false) { // black just moved
			loadimage(0, "images/win.jpg");
		}
		else {
			loadimage(0, "images/lose.jpg");
		}

		_getch();
		return true;
	}
	
	return false;
}

void Chess::updateGameMap(ChessPos* pos)
{

	lastPos = *pos;

	chessMap[pos->row][pos->col] = playerFlag ? CHESS_BLACK : CHESS_WHITE;
	playerFlag = !playerFlag;// switch back and white
}

bool Chess::checkWin()
{
	int row = lastPos.row;
	int col = lastPos.col;

	
	//check horizonal
	for (int i = 0; i < 5; i += 1) {
		if (col - i >= 0 && col - i + 4 < gradeSize && chessMap[row][col - i] == chessMap[row][col - i + 1] && chessMap[row][col - i] == chessMap[row][col - i + 2] && chessMap[row][col - i] == chessMap[row][col - i + 3] && chessMap[row][col - i] == chessMap[row][col - i + 4]) {
			return true;
		}
	}

	//check vertical
	for (int i = 0; i < 5; i += 1) {
		if (row - i >= 0 && row - i + 4 < gradeSize && chessMap[row - i][col] == chessMap[row - i + 1][col] && chessMap[row - i][col] == chessMap[row - i + 2][col] && chessMap[row - i][col] == chessMap[row - i + 3][col] && chessMap[row - i][col] == chessMap[row - i + 4][col]) {
			return true;
		}
	}

	//check angel
	for (int i = 0; i < 5; i += 1) {
		if (row + i < gradeSize && row + i - 4 >= 0 && col - i >= 0 && col - i + 4 < gradeSize && chessMap[row + i][col - i] == chessMap[row + i - 1][col - i + 1] && chessMap[row + i][col - i] == chessMap[row + i - 2][col - i + 2] && chessMap[row + i][col - i] == chessMap[row + i - 3][col - i + 3] && chessMap[row + i][col - i] == chessMap[row + i - 4][col - i + 4]) {
			return true;
		}
	}

	//check angel reverse
	for (int i = 0; i < 5; i += 1) {
		if (row - i >= 0 && row - i + 4 < gradeSize && col - i >= 0 && col - i + 4 < gradeSize && chessMap[row - i][col - i] == chessMap[row - i + 1][col - i + 1] && chessMap[row - i][col - i] == chessMap[row - i + 2][col - i + 2] && chessMap[row - i][col - i] == chessMap[row - i + 3][col - i + 3] && chessMap[row - i][col - i] == chessMap[row - i + 4][col - i + 4]) {
			return true;
		}
	}
	
	return false;
}
