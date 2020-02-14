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
    userKeeps: [],
    vaults: [],
    activeVault: {},
    keepsInActiveVault: {}
  },
  mutations: {
    setResource(state, payload) {
      state[payload.resource] = payload.data;
    }
  },
  actions: {
    //#region -- AUTH --
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    //#endregion
    //#region -- KEEPS --
    async getKeeps({ commit, dispatch }) {
      let res1 = await api.get("keeps");
      commit("setResource", { resource: "publicKeeps", data: res1.data });
      let res2 = await api.get("keeps/user");
      commit("setResource", { resource: "userKeeps", data: res2.data });
    },
    async createKeep({ commit, dispatch }, newKeep) {
      await api.post("keeps", newKeep);
      dispatch("getKeeps");
    },
    async editKeep({ commit, dispatch }, { update, id }) {
      await api.put("keeps/" + id, update, id);
      dispatch("getKeeps");
    },
    async deleteKeep({ commit, dispatch }, keepId) {
      await api.delete("keeps/" + keepId);
      dispatch("getKeeps");
    },
    //#endregion
    //#region -- VAULTS --
    async getVaults({ commit, dispatch }) {
      let res = await api.get("vaults");
      commit("setResource", { resource: "vaults", data: res.data });
    },
    async getVaultById({ commit, dispatch }, vaultId) {
      let res = await api.get("vaults/" + vaultId, vaultId);
      commit("setResource", { resource: "activeVault", data: res.data });
    },
    async makeVault({ commit, dispatch }, newVault) {
      await api.post("vaults", newVault);
      dispatch("getVaults");
    },
    async deleteVault({ commit, dispatch }, vaultId) {
      await api.delete("vaults/" + vaultId, vaultId);
      dispatch("getVaults");
    },
    //#endregion
    //#region -- KEEPS in VAULTS --
    async getKeepsByVaultId({ commit, dispatch }, vaultId) {
      let res = await api.get("vaultkeeps/" + vaultId + "/keeps");
      commit("setResource", { resource: "keepsInActiveVault", data: res.data });
    },
    async addKeepToVault({ commit, dispatch }, { keepData, vaultId }) {
      let keepId = keepData.id;
      let res = await api.post("vaultkeeps", { keepId, vaultId });
      if (res.data) {
        keepData.keeps++;
        dispatch("editKeep", { update: keepData, id: keepId });
      }
    },
    async removeKeepFromVault({ commit, dispatch }, { keepId, vaultId }) {
      await api.delete("vaultkeeps/" + vaultId + "/keeps/" + keepId);
      dispatch("getKeepsByVaultId", vaultId);
    }
    //#endregion
  }
});
