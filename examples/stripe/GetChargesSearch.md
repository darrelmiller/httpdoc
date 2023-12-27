<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">GetChargesSearch</h1><p  class="requestDescription"><p>Search for charges you’ve previously created using Stripe’s <a href="/docs/search#search-query-language">Search Query Language</a>.
Don’t use search in read-after-write flows where strict consistency is necessary. Under normal operating
conditions, data is searchable in less than a minute. Occasionally, propagation of new or updated data can be up
to an hour behind during outages. Search functionality is not available to merchants in India.</p></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">GET</span> <span  class="httpTarget">+{baseUrl}\v1\charges\search{?expand*,limit*,page*,query*}</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">example.org:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">expand</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">array</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">Specifies which fields in the response should be expanded.</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">limit</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">integer</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">page</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">A cursor for pagination across multiple pages of results. Don't include this parameter on the first call. Use the next_page value returned in a previous response to request subsequent results.</span> <span  class="parameterRequired">optional</span></dd><dt  class="parameter"><span  class="parameterName">query</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The search query string. See [search query language](https://stripe.com/docs/search#search-query-language) and the list of supported [query fields for charges](https://stripe.com/docs/search#query-fields-for-charges).</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema"></pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">Successful response.</span></li><li  class="response"><span  class="statusLine">default</span> <span  class="statusDescription">Error response.</span></li></ul></section></article></body></html>