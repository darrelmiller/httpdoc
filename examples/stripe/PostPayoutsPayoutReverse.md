<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">PostPayoutsPayoutReverse</h1><p  class="requestDescription"><p>Reverses a payout by debiting the destination bank account. Only payouts for connected accounts to US bank accounts may be reversed at this time. If the payout is in the <code>pending</code> status, <code>/v1/payouts/:id/cancel</code> should be used instead.</p>

<p>By requesting a reversal via <code>/v1/payouts/:id/reverse</code>, you confirm that the authorized signatory of the selected bank account has authorized the debit on the bank account and that no other authorization is required.</p></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">+{baseUrl}\v1\payouts\{payout}\reverse</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">example.org:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">payout</span> [ in: <span  class="parameterLocation">Path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription"></span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema"></pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">Successful response.</span></li><li  class="response"><span  class="statusLine">default</span> <span  class="statusDescription">Error response.</span></li></ul></section></article></body></html>