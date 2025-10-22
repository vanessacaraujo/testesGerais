const fs = require('fs');
const HandleBars = require('handlebars');
const AWS = require('aws-sdk');
const { handler } = require('../main/envioEmailLambda.js');

jest.mock('aws-sdk', () => {
    const SES = {
        sendEmail: jest.fn().mockReturnThis(),
        promise: jest.fn().mockRsolvedValue({MessageId: '121212'})
    };
    return { SES : jest.fn(() => SES)};
});

test('deve enviar email com sucesso', async() =>{
    const event = { nomeColaborador: 'fulano', dataExpiracao: '2025-01-01'};
    const rsponse = await handler(event);

    expect(response.statusCode).toBe(200);
    expect(JSON.parse(response.Body).message).toBe("Email enviado com sucesso");


})

