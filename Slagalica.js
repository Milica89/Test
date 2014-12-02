var canvas = document.getElementById("canvas"),
	c = canvas.getContext("2d");
	
var a = 30;

var Figure = new Array(4);
var tačke = new Array(4); // Tačke figure

var Odabrana = null; // Odabrana figura


Figure[0] = {
	x: 100,
	y: 300,
	boja: "blue",
	brojač: 0
};

Figure[1] = {
	x: 200,
	y: 300,
	boja: "red",
	brojač: 0
};

Figure[2] = {
	x: 300,
	y: 300,
	boja: "green",
	brojač: 0
};

Figure[3] = {
	x: 400,
	y: 300,
	boja: "orange",
	brojač: 0
};

function Donja(tačka){
	// funkcija vraća krajnje donju tačku figure

	var donja = tačka[0].ty;

	for (var i = 1; i < 4; i++){
		if (tačka[i].ty > donja){
			donja = tačka[i].ty;
		}
	}

	return donja + a;
}

function Leva(tačka){
	// funkcija vraća krajnje levu tačku figure

	var leva = tačka[0].tx;

	for (var i = 1; i < 4; i++){
		if (tačka[i].tx < leva){
			leva = tačka[i].tx;
		}
	}

	return leva;
}

function Desna(tačka){
	// Funkcija vraća krajnje desnu tačku figure

	var desna = tačka[0].tx;

	for (var i = 1; i < 4; i++){
		if(tačka[i].tx > desna){
			desna = tačka[i].tx;
		}
	}

	return desna + a;
}


function ProveraFigure(e){
	// Proverava koja figura je odabrana (kliknuta)
	for (var i = 0; i < 4; i++){
		for (var j = 0; j < 4; j++){
			if(e.clientX >= tačke[i][j].tx && e.clientX <= tačke[i][j].tx + a && e.clientY >= tačke[i][j].ty && e.clientY <= tačke[i][j].ty + a){
				Odabrana = i;
				Figure[i].brojač++;
				break;
			}
		}
	}
}

function Crtaj(){

	ProveraSlagalice();

	// Dodeljuje tačke
	tačke[0] = [{tx: Figure[0].x, ty: Figure[0].y}, {tx: Figure[0].x, ty: Figure[0].y + a}, {tx: Figure[0].x, ty: Figure[0].y + 2 * a}, {tx: Figure[0].x - a, ty: Figure[0].y + 2 * a}],
	tačke[1] = [{tx: Figure[1].x, ty: Figure[1].y}, {tx: Figure[1].x, ty: Figure[1].y + a}, {tx: Figure[1].x + a, ty: Figure[1].y + a}, {tx: Figure[1].x + a, ty: Figure[1].y}],
	tačke[2] = [{tx: Figure[2].x, ty: Figure[2].y}, {tx: Figure[2].x, ty: Figure[2].y + a}, {tx: Figure[2].x + a, ty: Figure[2].y + a}, {tx: Figure[2].x + 2 * a, ty: Figure[2].y + a}],
	tačke[3] = [{tx: Figure[3].x, ty: Figure[3].y}, {tx: Figure[3].x, ty: Figure[3].y + a}, {tx: Figure[3].x, ty: Figure[3].y + 2 * a}, {tx: Figure[3].x, ty: Figure[3].y + 3 * a}];

	

	// Prvo "očisti" ceo canvas, pa onda crta sve iznova
	c.clearRect(0, 0, canvas.width, canvas.height);
	
	ProveraPreklapanja();

	// Crta sve figure
	for (var i = 0; i < 4; i++){
		c.fillStyle = Figure[i].boja;
		for (var j = 0; j < 4; j++){
			c.fillRect(tačke[i][j].tx, tačke[i][j].ty, a, a);
		}
	}

	// Crta mrežu u koju treba postaviti figure
	for (var i = 0; i < 4; i++){
		for (var j = 0; j < 4; j++){
			c.strokeRect(50 + i * a, 50 + j * a, a, a);
		}
	}

	requestAnimFrame(Crtaj);
}

canvas.onmousemove = function(e){
	if (Odabrana != null && Figure[Odabrana].brojač % 2 != 0){
		Figure[Odabrana].x = e.clientX;
		Figure[Odabrana].y = e.clientY;
	}
}

canvas.onclick = function(e){
	
	ProveraFigure(e);


	// Nema šetanja po mreži 

	for (var i = 0; i < 4; i++){
		for (var j = 0; j < 4; j++){
			if (Figure[Odabrana].x > 50 + i * a && Figure[Odabrana].x < 50 + (i + 1) * a && Figure[Odabrana].y > 50 + j * a && Figure[Odabrana].y < 50 + (j + 1) * a){
				
				Figure[Odabrana].x = 50 + i * a;
				Figure[Odabrana].y = 50 + j * a;

				if (Donja(tačke[Odabrana]) > 200 && Donja(tačke[Odabrana]) < 230){
					Figure[Odabrana].y -= a;
				}	

				if (Donja(tačke[Odabrana]) > 230 && Donja(tačke[Odabrana]) < 260){
					Figure[Odabrana].y -= 2 * a;
				}	

				if (Donja(tačke[Odabrana]) > 260 && Donja(tačke[Odabrana]) < 290){
					Figure[Odabrana].y -= 3 * a;
				}	

				if (Leva(tačke[Odabrana]) < 50 && Leva(tačke[Odabrana]) > 20){
					Figure[Odabrana].x = 80;
				}

				if (Desna(tačke[Odabrana]) > 200 && Desna(tačke[Odabrana]) < 230){
					Figure[Odabrana].x -= a;
				}

				if (Desna(tačke[Odabrana]) > 230 && Desna(tačke[Odabrana]) < 260){
					Figure[Odabrana].x -= 2 * a;
				}

			}
		}
	}

	if (Figure[Odabrana].y < 50 && Donja(tačke[Odabrana]) > 50 && Figure[Odabrana].x > 50 - a && Figure[Odabrana].x < 170){
		Figure[Odabrana].brojač = 1;
	}

	if (Figure[Odabrana].x < 50 - a && Figure[Odabrana].x > 50 -a && Figure[Odabrana].y > 50 - 2 * a && Figure[Odabrana].y < 170){
		Figure[Odabrana].brojač = 1;
	}

	if (Figure[Odabrana].x < 50 && Figure[Odabrana].x > 50 - a){
		Figure[Odabrana].brojač = 1;
	}

	if (Figure[Odabrana].x > 170 && Figure[Odabrana].x < 200 && Figure[Odabrana].y > 10 && Figure[Odabrana].y < 110){
		Figure[Odabrana].brojač = 1;
	}
}

Crtaj();

// Funkcija za restart dugme

function Restart(){
	for (var i = 0; i < 4; i++){
		Figure[i].x = 100 + i * 100;
		Figure[i].y = 300;
	}

	Odabrana = null;
	document.getElementById("paragraf").innerHTML = "";
}

function ProveraSlagalice(){
	// Funkcija proverava da li je slagalica složena

	var brojač = 0;

	for (var i = 0; i < 4; i++){
		if(Figure[i].x >= 50 && Figure[i].x <= 170 &&  Figure[i].y >= 50 && Figure[i].y <= 170){
			brojač++;
		}
	}

	if(brojač == 4 && Figure[Odabrana].brojač % 2 == 0){
		document.getElementById("paragraf").innerHTML = "SLAGALICA JE SLOŽENA!";
	}
}

function ProveraPreklapanja(){
	if(Odabrana != null){
		for (var i = 0; i < 4; i++){
			for (var j = 0; j < 4; j++){
				for (var p = 0; p < 4; p++){
					for (var q = p; q < 4; q++){
						if (i != j && tačke[i][p].tx == tačke[j][q].tx && tačke[i][p].ty == tačke[j][q].ty){
							document.getElementById("paragraf").innerHTML = "Ne sme biti preklapanja unutar mreže";
							Figure[Odabrana].brojač = 1; // Postavlja se brojač na jedan da figura ne bi bila ostavljena
						}
					}
				}

			}
		}
	}

	for (var r = 0; r < 4; r++){
		if (r != Odabrana  && Figure[r].brojač % 2 == 0){
			for (var i = 0; i < 4; i++){
				for (var j = 0; j < 4; j++){
					if (Figure[r].x > 50 + i * a && Figure[r].x < 50 + (i + 1) * a && Figure[r].y > 50 + j * a && Figure[r].y < 50 + (j + 1) * a){
						
						Figure[r].x = 50 + i * a;
						Figure[r].y = 50 + j * a;
					}
				}
			}

					if (Donja(tačke[r]) > 200 && Donja(tačke[r]) < 230){
						Figure[r].y -= a;
					}	

					if (Donja(tačke[r]) > 230 && Donja(tačke[r]) < 260){
						Figure[r].y -= 2 * a;
					}	

					if (Donja(tačke[r]) > 260 && Donja(tačke[r]) < 290){
						Figure[r].y -= 3 * a;
					}	

					if (Desna(tačke[r]) > 200 && Desna(tačke[r]) < 230){
						Figure[r].x -= a;
					}

					if (Desna(tačke[r]) > 230 && Desna(tačke[r]) < 260){
						Figure[r].x -= 2 * a;
					}

					if (Leva(tačke[r]) < 50 && Leva(tačke[r]) > 20){
						Figure[r].x = 80;
					}
		}
	}
}


	