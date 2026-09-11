#include "Delantero.h"

string Delantero::mostrarDescripcion() const {
	return "Delantero -> " + getNombre() + "Id: " + getId() + " Club: " + getClubActual() + " Valor: " + to_string(getValorMercado());
}

string Delantero::getPosicion() const {
	return "Delantero";
}