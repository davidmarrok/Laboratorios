#include "Defensa.h"

string Defensa::mostrarDescripcion() const {
	return "Defensa --> " + getNombre() + "Id: " + getId() + "Club: " + getClubActual() +" Valor: " + to_string(getValorMercado());
}

string Defensa::getPosicion() const {
	return "Defensa";
}