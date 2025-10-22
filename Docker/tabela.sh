#!/bin/bash


tabela="Entrevistas"

region="us-east-1" 

endpoint="http://localhost:4566"


echo "deletando tabela"

aws dynamodb delete-table \
--table-name $tabela \
--region $region \
--endpoint-url $endpoint


echo "Criando tabela"

#Criar a tabela
aws dynamodb create-table \
    --table-name $tabela \
    --attribute-definitions \
        AttributeName=cod_idef_reclamante,AttributeType=S \
        AttributeName=txt_objt_idef_entrevista,AttributeType=S \
    --key-schema \
        AttributeName=cod_idef_reclamante,KeyType=HASH \
        AttributeName=txt_objt_idef_entrevista,KeyType=RANGE \
    --provisioned-throughput \
        ReadCapacityUnits=5,WriteCapacityUnits=5 \
    --tags \
        Key=Environment,Value=Development \
	--region $region \
	--endpoint-url $endpoint

#aws dynamodb create-table \
#--table-name $tabela \
#--attribute-definitions Attributeflame=cod_idef_pess, AttributeType=S Attributellame=txt_objt_orde_invt, AttributeType=S \
#--key-schema Attributename=cod_idef_pess, KeyType=HASH Attributefiame=txt_objt_orde_invt, Key Type=RANGE \
#--provisioned-throughput ReadCapacityUnits=5, WriteCapacityUnits=5 \
#--region $region \
#--endpoint-url $endpoint



echo "Tabela $tabela criada com sucesso na região $region."

aws ses verify-email-identity --email-address teste@teste.com --region "us-east-1" --endpoint-url "http://localhost:4566"
#aws dynamodb scan --table-name "Entrevistas" --region "us-east-1" --endpoint-url "http://localhost:4566"

#aws dynamodb create-table --table-name "Entrevistas" --attribute-definitions Attributeflame=cod_idef_pess, AttributeType=S Attributellame=txt_objt_orde_invt, AttributeType=S --key-schema Attributename=cod_idef_pess, KeyType=HASH Attributefiame=txt_objt_orde_invt, Key Type=RANGE --region "us-east-1" --endpoint-url "http://localhost:4566"
#aws ses verify-email-identity --email-address user1@yourdomain.com --region "us-east-1" --endpoint-url "http://localhost:4566"
#aws ses --region "us-east-1" --endpoint-url "http://localhost:4566" verify-email-identity --email-address user1@yourdomain.com
#aws ses send-email --region "us-east-1" --endpoint-url "http://localhost:4566"  --from user1@yourdomain.com --destination file://destination.json --message file://message.json