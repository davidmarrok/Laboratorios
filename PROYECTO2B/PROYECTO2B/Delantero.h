#include "Jugador.h"

class Delantero : public Jugador
{
public:
	Delantero(string id, string nombre, int valorMercado, string clubActual)
		: Jugador(id, nombre, valorMercado, clubActual) {
	}

	string mostrarDescripcion() const override;
	string getPosicion() const override;
};