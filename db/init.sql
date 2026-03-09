CREATE TABLE pedidos (
    id SERIAL PRIMARY KEY,
    nome_cliente TEXT NOT NULL,
    email TEXT NOT NULL,
    endereco TEXT NOT NULL,
    meio_pagamento TEXT NOT NULL,
    criado_em TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE pedido_itens (
    id SERIAL PRIMARY KEY,
    pedido_id INT NOT NULL REFERENCES pedidos(id) ON DELETE CASCADE,
    produto_id INT NOT NULL,
    nome_produto TEXT NOT NULL,
    valor NUMERIC(10,2) NOT NULL,
    quantidade INT NOT NULL
);