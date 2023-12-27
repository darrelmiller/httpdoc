<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">ListMessage</h1><p  class="requestDescription">Retrieve a list of messages belonging to the account used to make the request</p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">GET</span> <span  class="httpTarget">+{baseUrl}\2010-04-01\Accounts\{AccountSid}\Messages.json{?To*,From*,DateSent*,DateSent%3C*,DateSent%3E*,PageSize*,Page*,PageToken*}</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">example.org:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">AccountSid</span> [ in: <span  class="parameterLocation">Path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Message resources to read.</span> <span  class="parameterRequired">required</span></dd><dt  class="parameter"><span  class="parameterName">To</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">Read messages sent to only this phone number.</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">From</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">Read messages sent from only this phone number or alphanumeric sender ID.</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">DateSent</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The date of the messages to show. Specify a date as `YYYY-MM-DD` in GMT to read only messages sent on this date. For example: `2009-07-06`. You can also specify an inequality, such as `DateSent<=YYYY-MM-DD`, to read messages sent on or before midnight on a date, and `DateSent>=YYYY-MM-DD` to read messages sent on or after midnight on a date.</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">DateSent<</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The date of the messages to show. Specify a date as `YYYY-MM-DD` in GMT to read only messages sent on this date. For example: `2009-07-06`. You can also specify an inequality, such as `DateSent<=YYYY-MM-DD`, to read messages sent on or before midnight on a date, and `DateSent>=YYYY-MM-DD` to read messages sent on or after midnight on a date.</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">DateSent></span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The date of the messages to show. Specify a date as `YYYY-MM-DD` in GMT to read only messages sent on this date. For example: `2009-07-06`. You can also specify an inequality, such as `DateSent<=YYYY-MM-DD`, to read messages sent on or before midnight on a date, and `DateSent>=YYYY-MM-DD` to read messages sent on or after midnight on a date.</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">PageSize</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">integer</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">How many resources to return in each list page. The default is 50, and the maximum is 1000.</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">Page</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">integer</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The page index. This value is simply for client state.</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">PageToken</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The page token. This is provided by the API.</span> <span  class="parameterRequired">optional</span></dd></dl><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">OK</span></li></ul></section></article></body></html>