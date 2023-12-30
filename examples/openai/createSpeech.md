<!DOCTYPE html><html><head><title>Generates audio from the input text.</title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">Generates audio from the input text.</h1><p  class="requestDescription"></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\audio\speech</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.openai.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/octet-stream</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/json</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "required": [
    "model",
    "input",
    "voice"
  ],
  "type": "object",
  "properties": {
    "model": {
      "anyOf": [
        {
          "type": "string"
        },
        {
          "enum": [
            "tts-1",
            "tts-1-hd"
          ],
          "type": "string"
        }
      ],
      "description": "One of the available [TTS models](/docs/models/tts): `tts-1` or `tts-1-hd`\n",
      "x-oaiTypeLabel": "string"
    },
    "input": {
      "maxLength": 4096,
      "type": "string",
      "description": "The text to generate audio for. The maximum length is 4096 characters."
    },
    "voice": {
      "enum": [
        "alloy",
        "echo",
        "fable",
        "onyx",
        "nova",
        "shimmer"
      ],
      "type": "string",
      "description": "The voice to use when generating the audio. Supported voices are `alloy`, `echo`, `fable`, `onyx`, `nova`, and `shimmer`. Previews of the voices are available in the [Text to speech guide](/docs/guides/text-to-speech/voice-options)."
    },
    "response_format": {
      "enum": [
        "mp3",
        "opus",
        "aac",
        "flac"
      ],
      "type": "string",
      "description": "The format to audio in. Supported formats are `mp3`, `opus`, `aac`, and `flac`.",
      "default": "mp3"
    },
    "speed": {
      "maximum": 4.0,
      "minimum": 0.25,
      "type": "number",
      "description": "The speed of the generated audio. Select a value from `0.25` to `4.0`. `1.0` is the default.",
      "default": 1
    }
  },
  "additionalProperties": false
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">OK</span></li></ul></section></article></body></html>