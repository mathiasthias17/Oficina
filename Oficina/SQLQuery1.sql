ALTER TABLE Funcionarios 
ADD email VARCHAR(200),
senha VARCHAR(6),
nivel int; 

ALTER TABLE Veiculos
 ADD Dono Varchar(max);


go
CREATE OR ALTER TRIGGER TRG_RegistrarCompraFinanceiro 
ON Estoque
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Financeiro
    (
        Tipo,
        Descricao,
        Valor,
        Status_Pagamento
    )
    SELECT
        'SAIDA',

        CONCAT(
            'Compra de ',
            P.Nome,
            ' - ',
            C.QuantidadeComprada,
            ' unidade(s)'
        ),

        CAST(
            C.QuantidadeComprada * P.Preco_Custo
            AS DECIMAL(10,2)
        ),

        'PENDENTE'

    FROM
    (
        SELECT
            I.ID_Peca,

            CASE
                WHEN D.ID_Estoque IS NULL
                    THEN I.Quantidade

                ELSE I.Quantidade - D.Quantidade
            END AS QuantidadeComprada

        FROM inserted I

        LEFT JOIN deleted D
            ON I.ID_Estoque = D.ID_Estoque

    ) C

    INNER JOIN Pecas P
        ON P.ID_Peca = C.ID_Peca

    WHERE
        C.QuantidadeComprada > 0
        AND P.Preco_Custo > 0;

END;
GO

insert into Funcionarios (nome, CPF, Cargo, Telefone, Salario, Data_Admissao, email, senha, nivel) values ('miguel', '547.699.808-09', 'Programador', '(15) 99999-1111', '6000.00', '2018-03-05', 'miguelprogramador@email.com', '123456', 1);