<!DOCTYPE html><html><head><title>Translates audio into English.</title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">Translates audio into English.</h1><p  class="requestDescription"></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\audio\translations</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.openai.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">multipart/form-data</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "required": [
    "file",
    "model"
  ],
  "type": "object",
  "properties": {
    "file": {
      "type": "string",
      "description": "The audio file object (not file name) translate, in one of these formats: flac, mp3, mp4, mpeg, mpga, m4a, ogg, wav, or webm.\n",
      "format": "binary",
      "x-oaiTypeLabel": "file"
    },
    "model": {
      "anyOf": [
        {
          "type": "string"
        },
        {
          "enum": [
            "whisper-1"
          ],
          "type": "string"
        }
      ],
      "description": "ID of the model to use. Only `whisper-1` is currently available.\n",
      "example": "whisper-1",
      "x-oaiTypeLabel": "string"
    },
    "prompt": {
      "type": "string",
      "description": "An optional text to guide the model's style or continue a previous audio segment. The [prompt](/docs/guides/speech-to-text/prompting) should be in English.\n"
    },
    "response_format": {
      "type": "string",
      "description": "The format of the transcript output, in one of these options: `json`, `text`, `srt`, `verbose_json`, or `vtt`.\n",
      "default": "json"
    },
    "temperature": {
      "type": "number",
      "description": "The sampling temperature, between 0 and 1. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic. If set to 0, the model will use [log probability](https://en.wikipedia.org/wiki/Log_probability) to automatically increase the temperature until certain thresholds are hit.\n",
      "default": 0
    }
  },
  "additionalProperties": false
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">OK</span></li></ul></section></article></body></html>