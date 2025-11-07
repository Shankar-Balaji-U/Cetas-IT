## **Power BI Project – Data Connectivity and Performance Optimization**

### **Overview**

The Power BI project involves three main tables from the data model:

| Table Name              | Approx. Row Count | Refresh Frequency | Description                                                            |
| ----------------------- | ----------------- | ----------------- | ---------------------------------------------------------------------- |
| **Portfolio History**    | 4–6 million+      | Daily (once)      | Historical transactional data used for position-level reporting        |
| **Delta Ratio** | 80–100            | Frequent          | Mapping and reference ratios for hedging calculations                  |
| **Market Future Price**      | 18,000+           | Frequent          | Futures price and contract data used for price lookup and calculations |

The client requirement is to build a **Power BI report using DirectQuery mode** for all data sources to ensure real-time updates without importing large datasets.

---

### **Problem Statement**

While DirectQuery provides live connectivity, it has significant limitations when handling large datasets (especially multi-million-row tables). The main challenges faced were:

* Query result size limitations from the source.
* Slow report rendering and visual interaction.
* High DAX computation overhead in DirectQuery mode.
* Caching inconsistencies when combining DirectQuery and calculated elements.

---

### **Experiment Summary and Findings**

#### **1️⃣ All Tables in DirectQuery Mode**

* **Setup:** All tables (`Portfolio History`, `Delta Ratio`, `Market Future Price`) were connected using DirectQuery. All measures were created in DAX.
* **Issue:** Report rendering failed due to query size.
  **Error:** “The resultset of a query to external data source has exceeded the maximum allowed rows.”
* **Optimization Attempt:** Rewrote and optimized DAX measures to minimize context transitions and nested `SUMX`.
* **Outcome:** Report worked but visuals took **30–50 seconds** to load.
* **Conclusion:** Not feasible for production due to performance.

---

#### **2️⃣ Using `SUMMARIZE` Table in DirectQuery**

* **Setup:** Created a new summarized table in Power BI using `SUMMARIZE` on `Portfolio History`, converting key measures into columns.
* **Observation:** Performance improved drastically; visuals loaded instantly.
* **Limitation:** Summarized table data **did not refresh** dynamically with source updates unless schema changes were made.
* **Reason:** `SUMMARIZE` creates a static snapshot at design time, not a live query.
* **Conclusion:** High performance but not suitable for real-time reporting.

---

#### **3️⃣ Dataflow-Level Pre-Aggregation**

* **Setup:** Built a Power BI Dataflow that combines and aggregates `Portfolio History`, `Delta Ratio`, and `Market Future Price` before loading.
* **Observation:** Dataflow queries ran slowly, and applying transformations (joins, filters, aggregations) caused refresh failures.
* **Conclusion:** Dataflow-level pre-aggregation caused high load on the source and was unstable for large volumes.

---

#### **4️⃣ Enriching `Portfolio History` with Master Data (All in DirectQuery)**

* **Setup:** Added descriptive fields (name/description) from master tables into `Portfolio History`.
  All tables remained in DirectQuery mode; aggregations done in DAX.
* **Outcome:** Functional but performance degraded due to complex cross-table joins executed at query time.
* **Visual Load Time:** Still high.
* **Conclusion:** Minimal benefit; still bottlenecked by DirectQuery latency.

---

#### **5️⃣ Mixed Storage Mode (Hybrid Model)**

* **Setup:**

  * `Portfolio History` → **Import mode** (since it changes once daily)
  * `Delta Ratio` and `Market Future Price` → **DirectQuery mode**
* **Outcome:**

  * Drastically improved performance for visuals.
  * Data freshness maintained for frequently changing smaller tables.
  * Controlled refresh schedule for the large static table.
* **Conclusion:** **Best trade-off between performance and data freshness.**
  Hybrid mode effectively balanced DirectQuery limits and import flexibility.

---

### **Final Recommendation**

| Scenario                      | Performance | Data Freshness     | Maintenance | Suitable for Production? |
| ----------------------------- | ----------- | ------------------ | ----------- | ------------------------ |
| All DirectQuery               | Poor        | High               | Medium      | ❌                        |
| Summarize Table (Static)      | Excellent   | None               | Low         | ❌                        |
| Dataflow Pre-Aggregation      | Poor        | Medium             | High        | ❌                        |
| DirectQuery with Master Merge | Poor        | High               | Medium      | ❌                        |
| **Hybrid Storage Mode**       | **Good**    | **High (partial)** | **Low**     | ✅ **Recommended**        |

---

### **Key Learnings**

1. **DirectQuery isn’t scalable** for multi-million-row transactional data; use it selectively for smaller or frequently changing tables.
2. **SUMMARIZE tables** provide speed but sacrifice real-time accuracy.
3. **Hybrid (Import + DirectQuery) storage mode** is the most practical balance between performance and freshness.
4. Always **push transformations to the source** (SQL view or database layer) when possible; avoid complex Power Query logic on DirectQuery sources.
5. Optimize DAX to minimize row context operations (`SUMX`, `FILTER`, etc.) on DirectQuery tables.
