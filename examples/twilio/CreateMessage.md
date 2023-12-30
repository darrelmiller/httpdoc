<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">CreateMessage</h1><p  class="requestDescription">Send a message from the account used to make the request</p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\2010-04-01\Accounts\{AccountSid}\Messages.json</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.twilio.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/x-www-form-urlencoded</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">AccountSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that will create the resource.</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "title": "CreateMessageRequest",
  "required": [
    "To"
  ],
  "type": "object",
  "properties": {
    "AddressRetention": {
      "enum": [
        "retain"
      ],
      "type": "string"
    },
    "ApplicationSid": {
      "maxLength": 34,
      "minLength": 34,
      "pattern": "^AP[0-9a-fA-F]{32}$",
      "type": "string",
      "description": "The SID of the application that should receive message status. We POST a `message_sid` parameter and a `message_status` parameter with a value of `sent` or `failed` to the [application](https://www.twilio.com/docs/usage/api/applications)'s `message_status_callback`. If a `status_callback` parameter is also passed, it will be ignored and the application's `message_status_callback` parameter will be used."
    },
    "Attempt": {
      "type": "integer",
      "description": "Total number of attempts made ( including this ) to send out the message regardless of the provider used"
    },
    "Body": {
      "type": "string",
      "description": "The text of the message you want to send. Can be up to 1,600 characters in length."
    },
    "ContentRetention": {
      "enum": [
        "retain"
      ],
      "type": "string"
    },
    "ContentSid": {
      "maxLength": 34,
      "minLength": 34,
      "pattern": "^HX[0-9a-fA-F]{32}$",
      "type": "string",
      "description": "The SID of the Content object returned at Content API content create time (https://www.twilio.com/docs/content-api/create-and-send-your-first-content-api-template#create-a-template). If this parameter is not specified, then the Content API will not be utilized."
    },
    "ContentVariables": {
      "type": "string",
      "description": "Key-value pairs of variable names to substitution values, used alongside a content_sid. If not specified, Content API will default to the default variables defined at create time."
    },
    "ForceDelivery": {
      "type": "boolean",
      "description": "Reserved"
    },
    "From": {
      "type": "string",
      "description": "A Twilio phone number in [E.164](https://www.twilio.com/docs/glossary/what-e164) format, an [alphanumeric sender ID](https://www.twilio.com/docs/sms/send-messages#use-an-alphanumeric-sender-id), or a [Channel Endpoint address](https://www.twilio.com/docs/sms/channels#channel-addresses) that is enabled for the type of message you want to send. Phone numbers or [short codes](https://www.twilio.com/docs/sms/api/short-code) purchased from Twilio also work here. You cannot, for example, spoof messages from a private cell phone number. If you are using `messaging_service_sid`, this parameter must be empty.",
      "format": "phone-number"
    },
    "MaxPrice": {
      "type": "number",
      "description": "The maximum total price in US dollars that you will pay for the message to be delivered. Can be a decimal value that has up to 4 decimal places. All messages are queued for delivery and the message cost is checked before the message is sent. If the cost exceeds `max_price`, the message will fail and a status of `Failed` is sent to the status callback. If `MaxPrice` is not set, the message cost is not checked."
    },
    "MediaUrl": {
      "type": "array",
      "items": {
        "type": "string",
        "format": "uri"
      },
      "description": "The URL of the media to send with the message. The media can be of type `gif`, `png`, and `jpeg` and will be formatted correctly on the recipient's device. The media size limit is 5MB for supported file types (JPEG, PNG, GIF) and 500KB for [other types](https://www.twilio.com/docs/sms/accepted-mime-types) of accepted media. To send more than one image in the message body, provide multiple `media_url` parameters in the POST request. You can include up to 10 `media_url` parameters per message. You can send images in an SMS message in only the US and Canada."
    },
    "MessagingServiceSid": {
      "maxLength": 34,
      "minLength": 34,
      "pattern": "^MG[0-9a-fA-F]{32}$",
      "type": "string",
      "description": "The SID of the [Messaging Service](https://www.twilio.com/docs/sms/services#send-a-message-with-copilot) you want to associate with the Message. Set this parameter to use the [Messaging Service Settings and Copilot Features](https://www.twilio.com/console/sms/services) you have configured and leave the `from` parameter empty. When only this parameter is set, Twilio will use your enabled Copilot Features to select the `from` phone number for delivery."
    },
    "PersistentAction": {
      "type": "array",
      "items": {
        "type": "string"
      },
      "description": "Rich actions for Channels Messages."
    },
    "ProvideFeedback": {
      "type": "boolean",
      "description": "Whether to confirm delivery of the message. Set this value to `true` if you are sending messages that have a trackable user action and you intend to confirm delivery of the message using the [Message Feedback API](https://www.twilio.com/docs/sms/api/message-feedback-resource). This parameter is `false` by default."
    },
    "ScheduleType": {
      "enum": [
        "fixed"
      ],
      "type": "string"
    },
    "SendAsMms": {
      "type": "boolean",
      "description": "If set to True, Twilio will deliver the message as a single MMS message, regardless of the presence of media."
    },
    "SendAt": {
      "type": "string",
      "description": "The time that Twilio will send the message. Must be in ISO 8601 format.",
      "format": "date-time"
    },
    "ShortenUrls": {
      "type": "boolean",
      "description": "Determines the usage of Click Tracking. Setting it to `true` will instruct Twilio to replace all links in the Message with a shortened version based on the associated Domain Sid and track clicks on them. If this parameter is not set on an API call, we will use the value set on the Messaging Service. If this parameter is not set and the value is not configured on the Messaging Service used this will default to `false`."
    },
    "SmartEncoded": {
      "type": "boolean",
      "description": "Whether to detect Unicode characters that have a similar GSM-7 character and replace them. Can be: `true` or `false`."
    },
    "StatusCallback": {
      "type": "string",
      "description": "The URL we should call using the `status_callback_method` to send status information to your application. If specified, we POST these message status changes to the URL: `queued`, `failed`, `sent`, `delivered`, or `undelivered`. Twilio will POST its [standard request parameters](https://www.twilio.com/docs/sms/twiml#request-parameters) as well as some additional parameters including `MessageSid`, `MessageStatus`, and `ErrorCode`. If you include this parameter with the `messaging_service_sid`, we use this URL instead of the Status Callback URL of the [Messaging Service](https://www.twilio.com/docs/sms/services/api). URLs must contain a valid hostname and underscores are not allowed.",
      "format": "uri"
    },
    "To": {
      "type": "string",
      "description": "The destination phone number in [E.164](https://www.twilio.com/docs/glossary/what-e164) format for SMS/MMS or [Channel user address](https://www.twilio.com/docs/sms/channels#channel-addresses) for other 3rd-party channels.",
      "format": "phone-number"
    },
    "ValidityPeriod": {
      "type": "integer",
      "description": "How long in seconds the message can remain in our outgoing message queue. After this period elapses, the message fails and we call your status callback. Can be between 1 and the default value of 14,400 seconds. After a message has been accepted by a carrier, however, we cannot guarantee that the message will not be queued after this period. We recommend that this value be at least 5 seconds."
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">201</span> <span  class="statusDescription">Created</span></li></ul></section></article></body></html>