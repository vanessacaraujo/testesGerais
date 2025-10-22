const express = require('express');
const bodyParser = require('body-parser');
const app = express();
const PORT = 5001;

app.use(bodyParser.urlencoded({ extended: true }));


app.post('/introspect', (req, res) => {

  console.log(`Chamada para introspect`);

  const token = req.body.token;

  if (token === 'token-valido') {
    return res.json({
      ativo: true,
      nome: 'Jose autenticado',
      email: 'jose@email.com.br',
      escopo: 'api.read,api.write,todososacessos'
    });
  }

  return res.json({ ativo: false });
});

app.listen(PORT, () => {
  console.log(`Fake introspection rodando em http://localhost:${PORT}`);
});