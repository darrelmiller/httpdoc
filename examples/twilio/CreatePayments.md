<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">CreatePayments</h1><p  class="requestDescription">create an instance of payments. This will start a new payments session</p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\2010-04-01\Accounts\{AccountSid}\Calls\{CallSid}\Payments.json</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.twilio.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/x-www-form-urlencoded</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">AccountSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that will create the resource.</span> <span  class="parameterRequired">required</span></dd><dt  class="parameter"><span  class="parameterName">CallSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the call that will create the resource. Call leg associated with this sid is expected to provide payment information thru DTMF.</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "title": "CreatePaymentsRequest",
  "required": [
    "IdempotencyKey",
    "StatusCallback"
  ],
  "type": "object",
  "properties": {
    "BankAccountType": {
      "enum": [
        "consumer-checking",
        "consumer-savings",
        "commercial-checking"
      ],
      "type": "string"
    },
    "ChargeAmount": {
      "type": "number",
      "description": "A positive decimal value less than 1,000,000 to charge against the credit card or bank account. Default currency can be overwritten with `currency` field. Leave blank or set to 0 to tokenize."
    },
    "Currency": {
      "type": "string",
      "description": "The currency of the `charge_amount`, formatted as [ISO 4127](http://www.iso.org/iso/home/standards/currency_codes.htm) format. The default value is `USD` and all values allowed from the Pay Connector are accepted."
    },
    "Description": {
      "type": "string",
      "description": "The description can be used to provide more details regarding the transaction. This information is submitted along with the payment details to the Payment Connector which are then posted on the transactions."
    },
    "IdempotencyKey": {
      "type": "string",
      "description": "A unique token that will be used to ensure that multiple API calls with the same information do not result in multiple transactions. This should be a unique string value per API call and can be a randomly generated."
    },
    "Input": {
      "type": "string",
      "description": "A list of inputs that should be accepted. Currently only `dtmf` is supported. All digits captured during a pay session are redacted from the logs."
    },
    "MinPostalCodeLength": {
      "type": "integer",
      "description": "A positive integer that is used to validate the length of the `PostalCode` inputted by the user. User must enter this many digits."
    },
    "Parameter": {
      "description": "A single-level JSON object used to pass custom parameters to payment processors. (Required for ACH payments). The information that has to be included here depends on the <Pay> Connector. [Read more](https://www.twilio.com/console/voice/pay-connectors)."
    },
    "PaymentConnector": {
      "type": "string",
      "description": "This is the unique name corresponding to the Pay Connector installed in the Twilio Add-ons. Learn more about [<Pay> Connectors](https://www.twilio.com/console/voice/pay-connectors). The default value is `Default`."
    },
    "PaymentMethod": {
      "enum": [
        "credit-card",
        "ach-debit"
      ],
      "type": "string"
    },
    "PostalCode": {
      "type": "boolean",
      "description": "Indicates whether the credit card postal code (zip code) is a required piece of payment information that must be provided by the caller. The default is `true`."
    },
    "SecurityCode": {
      "type": "boolean",
      "description": "Indicates whether the credit card security code is a required piece of payment information that must be provided by the caller. The default is `true`."
    },
    "StatusCallback": {
      "type": "string",
      "description": "Provide an absolute or relative URL to receive status updates regarding your Pay session. Read more about the [expected StatusCallback values](https://www.twilio.com/docs/voice/api/payment-resource#statuscallback)",
      "format": "uri"
    },
    "Timeout": {
      "type": "integer",
      "description": "The number of seconds that <Pay> should wait for the caller to press a digit between each subsequent digit, after the first one, before moving on to validate the digits captured. The default is `5`, maximum is `600`."
    },
    "TokenType": {
      "enum": [
        "one-time",
        "reusable"
      ],
      "type": "string"
    },
    "ValidCardTypes": {
      "type": "string",
      "description": "Credit card types separated by space that Pay should accept. The default value is `visa mastercard amex`"
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">201</span> <span  class="statusDescription">Created</span></li></ul></section></article></body></html>