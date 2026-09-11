#pragma once
#include <string>
#include <vector>
#include "Club.h"
#include "Oferta.h"
#include "Transferencia.h"
#include "Jugador.h"
using namespace std;

class SimuladorMercado
{
private:
	vector<Club> clubes;
	vector<Jugador*> todosLosJugadores;
	vector<Oferta> ofertas;
	vector<Transferencia> historial;

	int diaActual;
	int diasTotales;
	string clubUsuario;
	int presupuestoInicialUsuario;
	vector<string> plantillaInicialIds;

	bool hayOfertaUsuarioPendiente;
	Oferta ofertaUsuarioPendiente;

	bool hayOfertaSistemaPendiente;
	Oferta ofertaSistemaPendiente;

	int totalGastado;
	int totalRecibido;
	int ofertasAceptadas;
	int ofertasRechazadas;
	int contadorOfertas;

	int contarPorPosicion(const Club& club, const string& posicion) const;
	Club* buscarClubPorId(const string& idClub);
	Club* buscarClubDeJugador(const string& idJugador);
	Jugador* buscarJugadorPorId(const string& idJugador);
	string generarIdOferta();
	int valorAleatorioPorPosicion(const string& posicion) const;
	void crearJugador(const string& idClub, const string& id, const string& nombre, const string& posicion);
	void moverJugadorEntreClubes(Jugador* jugador, const string& idOrigen, const string& idDestino);
	void mostrarJugador(const Jugador* jugador) const;
	void mostrarClubResumen(const Club& club) const;
	int leerEntero(const string& mensaje) const;
	string leerToken(const string& mensaje) const;

public:
	SimuladorMercado();
	~SimuladorMercado();

	void inicializarClubes();
	void asignarPresupuestos();
	void asignarValoresMercado();
	void configurarPartida();

	void verMiClub() const;
	void explorarJugadores(const string& filtro);
	void realizarOferta();
	void revisarOfertasRecibidas();
	void avanzarDia();
	void verHistorial() const;
	void generarReporteFinal() const;

	bool simulacionTerminada() const;
	void ejecutarMenu();
};