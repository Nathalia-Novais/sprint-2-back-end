USE T_Rental_N
GO

SELECT * FROM CLIENTE
SELECT * FROM ALUGUEL
SELECT * FROM MARCA
SELECT * FROM MODELO
SELECT * FROM VEICULO
SELECT * FROM EMPRESA

-- SELECT UTILIZANDO JOIN->

-- listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro

SELECT IdAluguel, nomeCliente, nomeModelo, placaVeiculo,dataAluguel , dataDevolucao  FROM ALUGUEL
LEFT JOIN VEICULO
ON VEICULO.IdVeiculo = ALUGUEL.IdVeiculo
INNER JOIN MODELO
ON MODELO.IdModelo = veiculo.IdModelo
LEFT JOIN CLIENTE
ON CLIENTE.IdCliente = ALUGUEL.IdCliente



-- listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro

SELECT IdAluguel, nomeCliente, nomeModelo, placaVeiculo,dataAluguel , dataDevolucao  FROM ALUGUEL
LEFT JOIN VEICULO
ON VEICULO.IdVeiculo = ALUGUEL.IdVeiculo
INNER JOIN MODELO
ON MODELO.IdModelo = veiculo.IdModelo
LEFT JOIN CLIENTE
ON CLIENTE.IdCliente = ALUGUEL.IdCliente
WHERE nomeCliente = 'Nathalia'


SELECT idCliente,nomeCliente, sobrenomeCliente,cpfCliente FROM CLIENTE

SELECT idVeiculo,ISNULL(VEICULO.idEmpresa,0),ISNULL(VEICULO.idModelo,0),nomeEmpresa,nomeModelo,placaVeiculo FROM VEICULO
INNER JOIN EMPRESA
ON EMPRESA.idEmpresa = VEICULO.idEmpresa
INNER JOIN MODELO
ON  MODELO.idModelo = VEICULO.idModelo

SELECT IdAluguel,ISNULL(ALUGUEL.idVeiculo,0),ISNULL(ALUGUEL.idCliente,0), nomeCliente, placaVeiculo,dataAluguel , dataDevolucao  FROM ALUGUEL
LEFT JOIN VEICULO
ON VEICULO.IdVeiculo = ALUGUEL.IdVeiculo
LEFT JOIN CLIENTE
ON CLIENTE.IdCliente = ALUGUEL.IdCliente

