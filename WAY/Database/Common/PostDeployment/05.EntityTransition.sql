-- Common
INSERT INTO [plt].[EntityTransition] ([Id], [ActionBeforeCode], [ActionAfterCode], [Order], [EntityStateFromId], [EntityStateToId], [IsSystem], [EntityLifecycleId]) VALUES
(1, 248, 249, 1, NULL, 1, 0, 1), /* NULL > Draft */
(2, 250, 251, 2, NULL, 2, 0, 1), /* NULL > Active */
(3, 252, 253, 3, 1, 2, 0, 1), /* Draft > Active */
(4, 254, 255, 4, 1, 4, 0, 1), /* Draft > Deleted */
(5, 256, 257, 5, 2, 3, 0, 1), /* Active > Blocked */
(6, 258, 259, 6, 2, 4, 0, 1), /* Active > Deleted */
(7, 260, 261, 7, 3, 2, 0, 1), /* Blocked > Active */
(8, 262, 263, 8, 3, 4, 0, 1), /* Blocked > Deleted */
(9, 264, 265, 9, 4, 1, 0, 1) /* Deleted > Draft */
