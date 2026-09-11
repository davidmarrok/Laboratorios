#pragma once
#include "Jugador.h"

class Defensa : public Jugador
{
public:
	Defensa(string id, string nombre, int valorMercado, string clubActual)
		: Jugador(id, nombre, valorMercado, clubActual) {
	}

	string mostrarDescripcion() const override;
	string getPosicion() const override;
};