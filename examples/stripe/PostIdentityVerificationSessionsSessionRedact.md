<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">PostIdentityVerificationSessionsSessionRedact</h1><p  class="requestDescription"><p>Redact a VerificationSession to remove all collected information from Stripe. This will redact
the VerificationSession and all objects related to it, including VerificationReports, Events,
request logs, etc.</p>

<p>A VerificationSession object can be redacted when it is in <code>requires_input</code> or <code>verified</code>
<a href="/docs/identity/how-sessions-work">status</a>. Redacting a VerificationSession in <code>requires_action</code>
state will automatically cancel it.</p>

<p>The redaction process may take up to four days. When the redaction process is in progress, the
VerificationSession’s <code>redaction.status</code> field will be set to <code>processing</code>; when the process is
finished, it will change to <code>redacted</code> and an <code>identity.verification_session.redacted</code> event
will be emitted.</p>

<p>Redaction is irreversible. Redacted objects are still accessible in the Stripe API, but all the
fields that contain personal data will be replaced by the string <code>[redacted]</code> or a similar
placeholder. The <code>metadata</code> field will also be erased. Redacted objects cannot be updated or
used for any purpose.</p>

<p><a href="/docs/identity/verification-sessions#redact">Learn more</a>.</p></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\v1\identity\verification_sessions\{session}\redact</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.stripe.com:443</span>
<span  class="headerLine">eTag</span>: <span  class="headerValue">"23423432"</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/x-www-form-urlencoded</span>

{ &quot;example&quot;: &quot;Example goes here&quot; }</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">session</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription"></span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{&#xA;  &quot;type&quot;: &quot;object&quot;,&#xA;  &quot;properties&quot;: {&#xA;    &quot;expand&quot;: {&#xA;      &quot;type&quot;: &quot;array&quot;,&#xA;      &quot;items&quot;: {&#xA;        &quot;maxLength&quot;: 5000,&#xA;        &quot;type&quot;: &quot;string&quot;&#xA;      },&#xA;      &quot;description&quot;: &quot;Specifies which fields in the response should be expanded.&quot;&#xA;    }&#xA;  },&#xA;  &quot;additionalProperties&quot;: false&#xA;}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">Successful response.</span></li><li  class="response"><span  class="statusLine">default</span> <span  class="statusDescription">Error response.</span></li></ul></section></article></body></html>