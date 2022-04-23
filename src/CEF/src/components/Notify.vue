<template>
  <div :class="$style.container">
    <div :class="$style.notify" v-for="(value, index) in Notify.Notifies" :key="index">
      <progress :value="value.Complete" max="100" :class="[$style.time, info[value.Type].progress]"></progress>
      <img :class="$style.image" :src="info[value.Type].image">
      <div :class="$style.text">
        <div :class="$style.header">{{ info[value.Type].header }}</div>
        <div :class="$style.message">{{value.Text}}</div>
      </div>
    </div>
  </div>
</template>

<script lang="ts" setup>
import {Notify} from "../stores/Notify";
import errorIcon from "@images/notify-error.svg";
import doneIcon from "@images/notify-done.svg";
import {useCssModule} from "vue";

const style = useCssModule();

const info = [
  {
    image: errorIcon,
    header: "Ошибка",
    progress: style.time_error
  },
  {
    image: doneIcon,
    header: "Успешно",
    progress: style.time_done
  }
]
</script>

<style lang="stylus" module>
.container
  pos(bottom:0)
  width 100vw
  flex(column, ialign: center)
  font-family 'Montserrat'
  color #fff

.image
  width 3vw

.notify
  position: relative;
  padding 0 1.25vw
  height 5.8vh
  margin-bottom 1vh
  background rgba(7, 7, 11, 0.6)
  border-radius 1.25vw
  flex(cont:center, ialign:center)

.text
  flex(column, center)

.header
  font-weight 600
  font-size 1.25vh

.message
  margin-top 0.5vh
  font-weight 500
  font-size 1vh
  color #6F6F6F

.time
  pos(top:0)
  width 75%
  appearance none

  &::-webkit-progress-bar
    width 100%
    height 0.1vh

.time_error
  &::-webkit-progress-bar
    background rgba(255, 255, 255, 0.1)

  &::-webkit-progress-value
    background #ff0000
    box-shadow 0 0 0.2vh 0.1vh rgba(220, 39, 39, 0.5)

.time_done
  &::-webkit-progress-bar
    background rgba(255, 255, 255, 0.1)

  &::-webkit-progress-value
    background #3CFF4F
    box-shadow 0 0 0.2vh 0.1vh rgba(41, 218, 59, 0.5)

</style>