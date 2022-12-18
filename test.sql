//создаем таблицу продуктов
CREATE TABLE pr.Prod(
	id INT NOT NULL DEFAULT '0',
	Name TEXT DEFAULT NULL,
    	PRIMARY KEY (`id`)
);

//вставляем значения в таблицу продуктов
INSERT INTO pr.Prod
VALUES
	(1, ''),
	(2, ''),
	(3, ''),
	(4, '');

//создаем таблицу категорий
CREATE TABLE pr.Cat(
	id INT NOT NULL DEFAULT '0',
	Name TEXT DEFAULT NULL,
    PRIMARY KEY (`id`)
);

//вставляем значения  таблицу категорий
INSERT INTO Cat
VALUES
	(1, ''),
	(2, '');

//создаем таблицу принадлености категори продуктам
CREATE TABLE pr.ProdCat(
	Id_P INT NOT NULL,
	Id_C INT NOT NULL,
	FOREIGN KEY (Id_P) REFERENCES pr.Prod(id),
	FOREIGN KEY (Id_C) REFERENCES pr.Cat(id),
	PRIMARY KEY (Id_P, Id_C)
);

//вставляем в таблицу принадлености категори продуктам из взаимосвязи
INSERT INTO Cat
VALUES
	(1, 1),
	(1, 2),
	(2, 1);
	(3, 2);

//выыводим
SELECT P.name, C.name
FROM pr.Prod P
LEFT JOIN pr.ProdCat PC
	ON P.Id = PC.Id_1
LEFT JOIN pr.Cat C
	ON PC.id_2 = C.Id;

