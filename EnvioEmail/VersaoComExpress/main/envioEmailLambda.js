const express = require("express");
const { SESClient, SendEmailCommand } = require("@aws-sdk/client-ses");
const fs = require("fs");
const path = require('path');
const HandleBars = require('handlebars');//lib para substituir placeholders no template do emaill
const app = express();
const port = 3002;
const remetente = 'avisocolaborador@email.com.br';
const templateDir = path.join(__dirname, '..', 'templates');

const sesClient = new SESClient({
    sslEnabled: false,
    region: "us-east-1",
    endpoint: "http://localhost:4566",
    credentials: {
        accessKeyId: "werqwer",
        secretAccessKey: "asdfasdfaoisjozozzz"
    }
});

app.use(express.json());

app.listen(port, () => {
    console.log(`Api na rota: http://localhost:${port}`);
});

app.post('/EnvioEmail', async (requisicao, resposta) => {
    try {
        var event = requisicao.body;
        var eventoAvisoExpiracao = event.avisoExpiracao || false;
        var templateEmail;
        var assuntoEmail;

        if (eventoAvisoExpiracao) {
            assuntoEmail = 'Aviso de expiração de entrevista digital';
            templateEmail = fs.readFileSync(path.join(templateDir, 'templateAvisoEmail.html'), () => { encoding: 'utf8' });
        }
        else {
            assuntoEmail = 'Convite para entrevista digital'
            templateEmail = fs.readFileSync(path.join(templateDir, 'templateEntrevistaEmail.html'), () => { encoding: 'utf8' });
        }

        var template = HandleBars.compile(templateEmail.toString('utf-8'));
        var corpoEmail = template({
            nomeColaborador: event.nomeColaborador || 'Colaborador',
            dataExpiracao: event.dataExpiracao,
            idEntrevista: event.idEntrevista
        });

        var requisicaoEnvioEmail = {
            Source: remetente,
            Destination: {
                ToAddress: [event.emailColaborador]
            },
            Message: {
                Subject: { Data: assuntoEmail },
                Body: {
                    Html: { Data: corpoEmail }
                }
            }
        };

        var command = new SendEmailCommand(requisicaoEnvioEmail);
        var responseSES = await sesClient.send(command);
        resposta.status(201).json({ mensagem: "Sucesso no envio:", detalhes: responseSES });
    } catch (erro) {
        resposta.status(500).json({ mensagem: "Falhan no envio:", detalhes: erro });
    }
});