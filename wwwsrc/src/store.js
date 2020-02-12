import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "./router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    userKeeps: []
  },
  mutations: {
    setResource(state, payload) {
      state[payload.resource] = payload.data;
    }
  },
  actions: {
    // #region -- AUTH --
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    // #endregion
    // #region -- KEEPS --
    async getKeeps({ commit, dispatch }) {
      let res1 = await api.get("keeps");
      commit("setResource", { resource: "publicKeeps", data: res1.data });
      let res2 = await api.get("keeps/user");
      commit("setResource", { resource: "userKeeps", data: res2.data });
    },
    // async getKeepById({ commit, dispatch }, keepId) {
    //   let res = await api.get("keeps/" + keepId)
    //   // if keep is private, commit to userKeeps, otherwise to publicKeeps
    //   // NOTE not gonna work because it blows away keeps with single keep
    //   if (res.data.isPrivate) {
    //     commit("setResource", { resource: "userKeeps", data: res.data})
    //   }
    //   else if (!res.data.isPrivate) {
    //     commit("setResource", { resource: "publicKeeps", data: res.data})
    //   }
    // },
    async createKeep({ commit, dispatch }, newKeep) {
      await api.post("keeps", newKeep);
      dispatch("getKeeps");
    },
    async editKeep({ commit, dispatch }, { update, id }) {
      console.log("keepupdate and id in store", update, id);
      await api.put("keeps/" + id, update, id);
      dispatch("getKeeps");
    },
    async deleteKeep({ commit, dispatch }, keepId) {
      await api.delete("keeps/" + keepId);
      dispatch("getKeeps");
    }
    // #endregion
  }
});
