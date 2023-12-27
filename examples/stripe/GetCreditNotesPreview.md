<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">GetCreditNotesPreview</h1><p  class="requestDescription"><p>Get a preview of a credit note without creating it.</p></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">GET</span> <span  class="httpTarget">+{baseUrl}\v1\credit_notes\preview{?amount*,credit_amount*,expand*,invoice*,lines*,memo*,metadata*,out_of_band_amount*,reason*,refund*,refund_amount*,shipping_cost*}</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">example.org:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">amount</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">integer</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The integer amount in cents (or local equivalent) representing the total amount of the credit note.</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">credit_amount</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">integer</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The integer amount in cents (or local equivalent) representing the amount to credit the customer's balance, which will be automatically applied to their next invoice.</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">expand</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">array</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">Specifies which fields in the response should be expanded.</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">invoice</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">ID of the invoice.</span> <span  class="parameterRequired">required</span></dd><dt  class="parameter"><span  class="parameterName">lines</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">array</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">Line items that make up the credit note.</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">memo</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The credit note's memo appears on the credit note PDF.</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">metadata</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">object</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">out_of_band_amount</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">integer</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The integer amount in cents (or local equivalent) representing the amount that is credited outside of Stripe.</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">reason</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">Reason for issuing this credit note, one of `duplicate`, `fraudulent`, `order_change`, or `product_unsatisfactory`</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">refund</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">ID of an existing refund to link this credit note to.</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">refund_amount</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">integer</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The integer amount in cents (or local equivalent) representing the amount to refund. If set, a refund will be created for the charge associated with the invoice.</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">shipping_cost</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">object</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">When shipping_cost contains the shipping_rate from the invoice, the shipping_cost is included in the credit note.</span> <span  class="parameterRequired">optional</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema"></pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">Successful response.</span></li><li  class="response"><span  class="statusLine">default</span> <span  class="statusDescription">Error response.</span></li></ul></section></article></body></html>