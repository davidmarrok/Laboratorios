#pragma once
#include <string>
#include <vector>
#include "Jugador.h"
using namespace std;

struct Club {
	string id;                  
	string nombre;
	int presupuesto;
	vector<Jugador*> jugadores;  
};