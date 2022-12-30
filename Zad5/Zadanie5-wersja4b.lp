% Zadanie 5 wersja 4b
% Set Covering Problem - przyklad z sluzba zdrowia w wsiach
% W kraju X znajduje sie 5 (od 1 do 5) wsi. Chcemy wybudowac jak najmniej szpitali,
% z czasem rekacji przynajmniej 15 minut. Odleglosc pomiedzy poszczegolnymi wsiami, przedstawia tabela ponizej:
% 0 1  2  3  4  5
% 1 0  10 30 30 50
% 2 15 0  25 45 20
% 3 30 25 0  15 10
% 4 40 55 10 0  10
% 5 40 35 30 15 0
% Poprawnym rozwiazaniem zadania sa wsie 1 i 4
% Zeby uruchomic program nalezy wejsc na strone:https://potassco.org/clingo/run/ 
% Skopiowac kod zrodlowy i uruchomic

%consts
#const numOfVillages = 5.
#const minDistance = 15.

villages(1..numOfVillages).

% Odleglosc pomiedzy miastami
space(1, 2, 10).
space(1, 3, 30).
space(1, 4, 30).
space(1, 5, 50).
space(2, 1, 15).
space(2, 3, 25).
space(2, 4, 45).
space(2, 5, 20).
space(3, 1, 30).
space(3, 2, 25).
space(3, 4, 15).
space(3, 5, 10).
space(4, 1, 40).
space(4, 2, 55).
space(4, 3, 10).
space(4, 5, 10).
space(5, 1, 40).
space(5, 2, 35).
space(5, 3, 30).
space(5, 4, 15).

space(Village,Village,0) :- villages(Village).

1 { x(Village) : villages(Village) } .

:- { x(Village2) : villages(Village2) , space(Village1, Village2, Distance) , Distance <= minDistance } 0, villages(Village1).  

#minimize {1,Village:x(Village) , villages(Village) }.

#show x/1.