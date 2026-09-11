#include <iostream>
#include <cstdlib>
#include <ctime>
#include "SimuladorMercado.h"

using namespace std;

int main() {
	srand(static_cast<unsigned int>(time(nullptr)));

	cout << "=========================================\n";
	cout << "   MERCATO 2026 - Simulador de Fichajes\n";
	cout << "=========================================\n";

	SimuladorMercado simulador;
	simulador.ejecutarMenu();

	return 0;
}