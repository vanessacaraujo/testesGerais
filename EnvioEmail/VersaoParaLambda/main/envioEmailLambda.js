const fs = require('fs'); //lib de filesystm
const HandleBars = require('handlebars');//lib para substituir placeholders no template do emaill
const AWS = require('aws-sdk')//lib da aws

const ses = new AWS.SES({
    region: 'us-east-1',
    endpoint: 'http://localhost:4566'
})

exports.handler = async (event) => {
    try {
        const eventoAvisoExpiracao = event.avisoExpiracao || false;
        const remetente = 'avisocolaborador@email.com.br';
        const templateEmail = eventoAvisoExpiracao
            ? fs.readFile('../templates/templateAvisoEmail.html', 'utf8')
            : fs.readFile('../templates/templateEntrevistaEmail.html', 'utf8')

        const assuntoEmail = eventoAvisoExpiracao
            ? 'Aviso de expiração de entrevista digital'
            : 'Convite para entrevista digital';

        const template = HandleBars.compile(templateEmail);
        const nomeColaborador = event.nomeColaborador || 'Colaborador';
        const dataExpiracao = event.dataExpiracao;
        const idEntrevista = event.idEntrevista;

        const corpoEmail = template({
            nome: nomeColaborador,
            dataExpiracao: dataExpiracao,
            idEntrevista: idEntrevista
        });

        const requisicaoEnvioEmail = {
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

        const resultadoEnvio =
            await ses.sendEmail(requisicaoEnvioEmail)
                .promise();

        return {
            statusCode: 200,
            body: JSON.stringify({ message: "Email enviado com sucesso", resultadoEnvio })
        }
    } catch (erro) {
        return {
            statusCode: 500,
            body: JSON.stringify({ message: "Erro no envio", erro })
        }
    }

}