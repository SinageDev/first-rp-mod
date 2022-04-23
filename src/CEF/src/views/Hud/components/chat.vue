<template>
  <div :class="$style.container">
    <div :class="$style.chat">
      <div :class="$style.message" v-for="(value, index) in Chat.messageList.value" :key="index">{{ value.text }}</div>
    </div>
    <input v-show="inputShow" :class="$style.input" @keyup.enter="trySendMessage"
           @keyup.esc="inputShow = false" @keyup.up="" @keyup.down=""
           v-model.trim="inputText" v-chat-input="inputShow">
  </div>
</template>

<script lang="ts" setup>
import {Directive, watchEffect} from "vue";
import {addTempKeyEvent} from "@services/keyEvent";
import {useChatStore} from "../../../stores/Chat";
import {storeToRefs} from "pinia";
import Rage from "@services/Rage";
import "@services/Cef";

const Chat = storeToRefs(useChatStore());

const vChatInput: Directive = {
  updated: (el, binding) => {
    if (binding.value == true && binding.value != binding.oldValue) el.focus();
  }
}

let inputText = $ref("");
let inputShow = $ref(false);

watchEffect(() => {
  if(inputShow) Rage.cursor.state(true, true);
  else Rage.cursor.state(false, false);
})

function trySendMessage() {
  inputShow = false;
  if (inputText.length == 0) return;
  if(inputText[0] == '/') {
    if(!inputText[1] || inputText[1] == ' ') return;
    const args = inputText.split(' ');
    Rage.trigger.server("Chat:TryCommand", args.shift()?.replace('/', ''), args);
  }
  else Rage.trigger.server("Chat:Message", inputText.substring(0, 144))
  inputText = "";
}

addTempKeyEvent((e: KeyboardEvent) => {
  if (e.keyCode == 84) inputShow = true;
});
</script>

<style lang="stylus" module>
.container
  position absolute
  left 2vw
  top 2vh

.chat
  width 30vw
  height 30vh

.message
  font(1.2vw, shadow:4)

.input
  width 100%
  font(1.25vw, shadow:2)
  background rgba(50, 50, 50, 0.5)
  border 0.2vw solid #000
  padding 0.5vh 0.5vw
</style>