USE T_Rental_N
GO

INSERT INTO EMPRESA (nomeEmpresa)
VALUES ('CARROS'),('CARROS2');
GO

INSERT INTO MARCA (nomeMarca)
VALUES ('gm'),('ford'),('fiat');
GO


INSERT INTO MODELO (idMarca,nomeModelo)
VALUES (1,'onix'), (2,'fiesta'), (3,'argo');
GO

INSERT INTO VEICULO(idEmpresa,idModelo,placaVeiculo)
VALUES (1,1,'2909'),(1,2,'1111'),(2,3,'aaaaaa');
GO

INSERT INTO CLIENTE (nomeCliente,sobrenomeCliente,cpfCliente)
VALUES('Nathalia','Novais','111111111'),('Maria','Guedes','2222222222'),('Andre','Silva','33333333')
GO

INSERT INTO ALUGUEL (idVeiculo,idCliente,dataAluguel,dataDevolucao)
VALUES (1,1,'01/02/20','04/02/20'),(2,3,'03/03/20','05/03/20'),(3,2,'04/05/20','12/05/20');
GO















