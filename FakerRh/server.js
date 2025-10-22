const express = require('express');
const fs = require('fs');
const app = express();
const PORT = 3000;

const db = JSON.parse(fs.readFileSync('db.json'));

app.get('/api/paresparceiros', (req, res) => {
  const { cpf, inicio, fim } = req.query;

    console.log(cpf, inicio, fim );

  if (!cpf || !inicio || !fim) {
    return res.status(400).json({ error: 'Parâmetros cpf, inicio e fim são obrigatórios.' });
  }

  const inicioDate = new Date(inicio);
  const fimDate = new Date(fim);

  const interacoes = db.interacoes.filter(i =>
    i.cpf1 === cpf &&
    new Date(i.data) >= inicioDate &&
    new Date(i.data) <= fimDate
  );

  const parceiros = interacoes.map(i => {
    const parceiro = db.paresparceiros.find(c => c.cpf === i.cpf2);
    return parceiro || null;
  }).filter(Boolean);

  res.json(parceiros);
});

app.listen(PORT, () => {
  console.log(`Servidor rodando em http://localhost:${PORT}`);
});
