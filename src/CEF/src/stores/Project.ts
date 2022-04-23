import {defineStore} from "pinia";

export const useProjectStore = defineStore("project", {
  state: () => ({
    name: "Name"
  })
})