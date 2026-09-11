#include <string>
#include "Jugador.h"
using namespace std;
struct Oferta {
	string id;
	Jugador* jugador;
	string comprador;
	string vendedor;
	int monto;
	string estado;
	string tipo;
};