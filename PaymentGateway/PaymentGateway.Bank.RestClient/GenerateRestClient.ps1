#npm install autorest -g
#autorest --latest
iwr https://localhost:44385/swagger/v1/swagger.json -o swagger.json
Remove-Item .\RestClient -Force -Recurse
autorest --input-file=swagger.json --csharp --version=2.0.4419 --add-credentials --output-folder=RestClient --namespace=PaymentGateway.Bank.RestClient --verbose --clear-output-folder=true
